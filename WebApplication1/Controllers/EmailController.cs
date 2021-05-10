using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess.Interfaces;

namespace WebApplication1.Controllers
{
    public class EmailController : Controller
    {
        private readonly IBlogsRepository _blogsRepo;
        private readonly IConfiguration _config;
        private readonly IPubSubRepository _pubSubRepo;

        public EmailController(IConfiguration config, IPubSubRepository pubSubRepository)
        {
            _config = config;           
            _pubSubRepo = pubSubRepository;
        }

        //public IActionResult Pull()
        //{
        //    //string msgSerialized =  _pubSubRepo.PullMessageA(DataAccess.Repositories.Category.luxury);

        //    //dynamic myDeserializedData = JsonConvert.DeserializeObject(msgSerialized);
        //    //string email = myDeserializedData.PassangerName;
        //    //string Name = myDeserializedData.Email;
        //    //string OrderId = myDeserializedData.BookingID;


        //    //RestClient client = new RestClient();
        //    //client.BaseUrl = new Uri ("https://api.mailgun.net/v3");
        //    //client.Authenticator = new HttpBasicAuthenticator("api", "77e3d24f5acab249bd5a5b01674d23ba-71b35d7e-233157ca");
        //    //RestRequest request = new RestRequest();
        //    //request.AddParameter("domain", "sandbox6e49ae25198143a28d7782ca77e4876a.mailgun.org", ParameterType.UrlSegment);
        //    //request.Resource = "{domain}/messages";
        //    //request.AddParameter("from", "Mailgun Sandbox <postmaster@sandbox6e49ae25198143a28d7782ca77e4876a.mailgun.org>");
        //    //request.AddParameter("to", Name);
        //    //request.AddParameter("subject", "Hello" + Name);
        //    //request.AddParameter("text", "Your Booking With Id" + OrderId + "Is accepted");
        //    //request.Method = Method.POST;
        //    //var response =  client.Execute(request);
        //    //return Content(response.StatusCode.ToString());

        //}
    }
}
