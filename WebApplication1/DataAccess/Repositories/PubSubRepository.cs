using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
        public void PublishMessage(Blog b, string email, string classType)
        {
            TopicName topicName = TopicName.FromProjectTopic(projectId, "pfc");

            Task<PublisherClient> t = PublisherClient.CreateAsync(topicName);
            t.Wait();
            PublisherClient publisher = t.Result;

            var myOnTheFlyObject = new { Email = email, Blog = b };

            string myOnTheFlyObject_serialized = JsonConvert.SerializeObject(myOnTheFlyObject);

            var pubsubMessage = new PubsubMessage
            {
                // The data is any arbitrary ByteString. Here, we're using text.
                Data = ByteString.CopyFromUtf8(myOnTheFlyObject_serialized),
                // The attributes provide metadata in a string-to-string dictionary.
                Attributes =
            {                
                { "category", classType }
            }
            };

            Task <string> t2 = publisher.PublishAsync(pubsubMessage);
            t2.Wait();

            string message = t2.Result; 
            
        }

        public string PullMessage(Category cat)
        {
            string subscriptionid;
            
            switch (cat)
            {
                case Category.buisness:
                    subscriptionid = "Subscription1";
                    break;

                case Category.economy:
                    subscriptionid = "Subscription2";
                    break;

                case Category.luxury:
                    subscriptionid = "Subscription3";
                    break;
            }
            SubscriptionName subscriptionName = SubscriptionName.FromProjectSubscription(projectId, "Subscription1");
            SubscriberServiceApiClient subscriberClient = SubscriberServiceApiClient.Create();
            int messageCount = 0;
            string text = " ";
            try
            {
                // Pull messages from server,
                // allowing an immediate response if there are no messages.
                PullResponse response = subscriberClient.Pull(subscriptionName, returnImmediately: true, maxMessages: 1);
                // Print out each received message.
                
                var msg = response.ReceivedMessages.FirstOrDefault();

                if (msg != null)
                {
                    text = msg.Message.Data.ToStringUtf8();
                }

                subscriberClient.Acknowledge(subscriptionName, new List<string>() { msg.AckId });
            }            
           
            catch (RpcException ex) when (ex.Status.StatusCode == StatusCode.Unavailable)
            {
                // UNAVAILABLE due to too many concurrent pull requests pending for the given subscription.
            }

            return text;
        }
    }
}
