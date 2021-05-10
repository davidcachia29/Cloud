using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess.Interfaces;
using WebApplication1.Models.Domain;

namespace WebApplication1.DataAccess.Repositories
{

    public enum Category { economy, buisness, luxury}
    public class PubSubRepository : IPubSubRepository
    {
        string projectId;
       

        public PubSubRepository(IConfiguration config)
        {           
            projectId = config.GetSection("AppSettings").GetSection("ProjectId").Value;            
        }


        public void PublishMessage(Booking b, string email, string classType)
        {
            TopicName topicName = TopicName.FromProjectTopic(projectId, "pfc");

            Task<PublisherClient> t = PublisherClient.CreateAsync(topicName);
            t.Wait();
            PublisherClient publisher = t.Result;

            var myOnTheFlyObject = new { Email = email, Blog = b };

            string myOnTheFlyObject_serialized = JsonConvert.SerializeObject(myOnTheFlyObject);

            var pubsubMessage = new PubsubMessage
            {
                
                Data = ByteString.CopyFromUtf8(myOnTheFlyObject_serialized),
                
                Attributes =
            {                
                { "category", classType }
            }
            };

            Task <string> t2 = publisher.PublishAsync(pubsubMessage);
            t2.Wait();

            string message = t2.Result; 
            
        }

        public string PullMessage(Category cat, string driver, string plate, int passAmount)
        {
            string subscriptionid = "Subscription3";

            switch (cat)
            {
                case Category.buisness:
                    subscriptionid = "Subscription2";
                    break;

                case Category.economy:
                    subscriptionid = "Subscription3";
                    break;

                case Category.luxury:
                    subscriptionid = "Subscription1";
                    break;
            }

            SubscriptionName subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionid);
            SubscriberServiceApiClient subscriberClient = SubscriberServiceApiClient.Create();
            int messageCount = 0;
            string text = " ";

            try
            {                
                
                PullResponse response = subscriberClient.Pull(subscriptionName, returnImmediately: true, maxMessages: 1);                
                
                var msg = response.ReceivedMessages.FirstOrDefault();

                if (msg != null)
                {
                    text = msg.Message.Data.ToStringUtf8();
                }

                subscriberClient.Acknowledge(subscriptionName, new List<string>() { msg.AckId });

                

                dynamic myDeserializedData = JsonConvert.DeserializeObject(text);
                string email = myDeserializedData.PassangerName;
                string Name = myDeserializedData.Email;
                string OrderId = myDeserializedData.Blog.BookingID;

                


                RestClient client = new RestClient();
                client.BaseUrl = new Uri("https://api.mailgun.net/v3");
                client.Authenticator = new HttpBasicAuthenticator("api", "77e3d24f5acab249bd5a5b01674d23ba-71b35d7e-233157ca");
                RestRequest request = new RestRequest();
                request.AddParameter("domain", "sandbox6e49ae25198143a28d7782ca77e4876a.mailgun.org", ParameterType.UrlSegment);
                request.Resource = "{domain}/messages";
                request.AddParameter("from", "Mailgun Sandbox <postmaster@sandbox6e49ae25198143a28d7782ca77e4876a.mailgun.org>");
                request.AddParameter("to", Name);
                request.AddParameter("subject", "Hello" + Name);
                request.AddParameter("text", "Your Booking With Id" + OrderId + " Is accepted");
                request.AddParameter("text","Your order is accepted by " + driver + " With Plate " + plate + " and passanger amount of " + passAmount);
                request.Method = Method.POST;
                var response1 = client.Execute(request);
                
            }            
           
            catch (RpcException ex) when (ex.Status.StatusCode == StatusCode.Unavailable)
            {
                
            }

            return text;
        }
    }
}
