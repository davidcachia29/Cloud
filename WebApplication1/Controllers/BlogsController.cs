using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess.Interfaces;
using WebApplication1.Models.Domain;

namespace WebApplication1.Controllers
{
    public class BlogsController : Controller

        
    {
        private readonly IBlogsRepository _blogsRepo;
        private readonly IConfiguration _config;
        private readonly IPubSubRepository _pubSubRepo;

        public BlogsController(IBlogsRepository blogsRepo, IConfiguration config, IPubSubRepository pubSubRepository)
        {
            _config = config;
            _blogsRepo = blogsRepo;
            _pubSubRepo = pubSubRepository;
        }
        public IActionResult Index()
        {
            var list = _blogsRepo.GetBlogs();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormFile logo, Blog b)
        {
            try
            {
                string bucketName = _config.GetSection("AppSettings").GetSection("BucketName").Value;

                string uniqueFilename = Guid.NewGuid() + System.IO.Path.GetExtension(logo.FileName);
                var storage = StorageClient.Create();

                using (var myStream = logo.OpenReadStream())
                {
                    storage.UploadObject(bucketName, uniqueFilename, null, myStream);
                }

                b.Url = $"https://storage.googleapis.com/{bucketName}/{uniqueFilename}";

                _blogsRepo.AddBlog(b);

                //string emailRecipient = HttpContext.User.Identity.Name;
                //_pubSubRepo.PublishMessage(b, emailRecipient, "Demo");

                TempData["message"] = $"Blog {b.Url} was created successfully";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = e;
                return View(b);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _blogsRepo.DeleteBlog(id);
                TempData["message"] = $"Blog was created successfully";

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["error"] = $"Blog was not created successfully";
               
            }
            return RedirectToAction("Index");
        }
    }
}
