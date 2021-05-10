using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.DataAccess.Interfaces;
using WebApplication1.Models.Domain;

namespace WebApplication1.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IConfiguration _config;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IDriverInfo _driverinfo;

        private readonly IPubSubRepository _pubSubRepo;
        public BookingsController(IBookingRepository bookingRepo, IConfiguration config, UserManager<IdentityUser> userManager, IPubSubRepository pubSubRepository, ApplicationDbContext context, IDriverInfo driverInfo)
        {
            _context = context;
            _config = config;
            _bookingRepo = bookingRepo;
            _userManager = userManager;
            _pubSubRepo = pubSubRepository;
            _driverinfo = driverInfo;
            
        }

        public IActionResult Index()
        {            
            var list = _bookingRepo.GetBookings();
            return View(list);            
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string lat, string lon, string cat, string lat1, string lon1)
        {
            
            try
            {
                //return RedirectToAction("Create");
                //string bucketName = _config.GetSection("AppSettings").GetSection("BucketName").Value;                //string bucketName = _config.GetSection("AppSettings").GetSection("BucketName").Value;

                //string uniqueFilename = Guid.NewGuid() + System.IO.Path.GetExtension(logo.FileName);
                //var storage = StorageClient.Create();

                //using (var myStream = logo.OpenReadStream())
                //{
                //    storage.UploadObject(bucketName, uniqueFilename, null, myStream);
                //}

                //b.Url = $"https://storage.googleapis.com/{bucketName}/{uniqueFilename}";

                string emailRecipient = HttpContext.User.Identity.Name;
                Booking b = new Booking();

                b.LanStart = lat;
                b.LonStart = lon;
                b.LonEnd = lon1;
                b.LanEnd = lat1;
                

                var currentLoggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                b.PassangerName = currentLoggedInUser.ToString();
                b.accepted = false;
                b.Categories = cat;

                
                _bookingRepo.AddBooking(b);

                

                _pubSubRepo.PublishMessage(b, emailRecipient, b.Categories);

                

                TempData["message"] = $"Booking with ID {b.BookingID} was created successfully";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Booking was not created successfully" + ex;
                return RedirectToAction("Index");
            }
        }

        

        public Booking GetBooking(int id)
        {
            return _context.Bookings.SingleOrDefault(x => x.BookingID == id);
        }
    }
}
