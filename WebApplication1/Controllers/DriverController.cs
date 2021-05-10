using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class DriverController : Controller
    {
        private readonly IBookingRepository _bookingRepo;        
        private readonly IConfiguration _config;
        private readonly IPubSubRepository _pubSubRepo;
        private readonly IDriverInfo _driverinfo;
        public readonly UserManager<IdentityUser> _userManager;

        public DriverController(UserManager<IdentityUser> userManager, IBookingRepository bookingRepo, IConfiguration config, IPubSubRepository pubSubRepository, IDriverInfo driverinfo)
        {
            _config = config;
            _bookingRepo = bookingRepo;
            _pubSubRepo = pubSubRepository;
            _userManager = userManager;
            _driverinfo = driverinfo;

        }

        public async Task<IActionResult> driverCategory(string role, Driver d, string Button, IFormFile logo)
        {
            var currentLoggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var CurrentRole = await _userManager.GetRolesAsync(currentLoggedInUser);

            string emailRecipeint = HttpContext.User.Identity.Name;
            var user = _userManager.FindByNameAsync(emailRecipeint);
            string id = user.Result.Id.ToString();

            foreach (string element in CurrentRole)
            {
                if (element == "DRIVER")
                {
                    if (role != null)
                    {
                        if (CurrentRole.Count == 1)
                        {
                            await _userManager.AddToRoleAsync(currentLoggedInUser, role);
                            _driverinfo.UpdateInfo(d, Button, id, logo);
                        }
                    }
                }

                else if(element != "DRIVER")
                {
                    if(role != null)
                    {
                        await _userManager.RemoveFromRolesAsync(currentLoggedInUser, CurrentRole);
                        await _userManager.AddToRoleAsync(currentLoggedInUser, "DRIVER");
                        await _userManager.AddToRoleAsync(currentLoggedInUser, role);
                        _driverinfo.UpdateInfo(d, Button, id, logo);
                    }

                }                
            }

            

            return View();

            
        }

        public IActionResult UpdateAcceptance(int BookingID, bool Accapted)
        {
            try
            {
                var currentLoggedInUser = _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

                string driverid = HttpContext.User.Identity.Name;

                Driver Total = _driverinfo.GetTotalInfo(currentLoggedInUser.Result.Id);

                _bookingRepo.UpdateAcceptance(BookingID, true, currentLoggedInUser.ToString(), driverid, Total.RegistrationPlate, Total.PassangerCapacity);
                

                TempData["message"] = $"Blog was created successfully";

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["error"] = $"Blog was not created successfully";

            }
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var list = _bookingRepo.GetBookings();
            return View(list);
        } public IActionResult AcceptedView()
        {
            var list = _bookingRepo.GetBookings();
            return View(list);
        }
    }
}
