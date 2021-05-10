using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class RolesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        
        public RolesController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
           
        }

        [HttpGet]
        public IActionResult ActionResult()
        {
            return View();
        }
        public async Task<IActionResult> AllocateRole(string role)
        {
            if(role == "DRIVER" || role == "PASSENGER" || role == "USER")
            {
                var currentLoggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                var CurrentRole = await _userManager.GetRolesAsync(currentLoggedInUser);
                await _userManager.RemoveFromRolesAsync(currentLoggedInUser, CurrentRole);
                await _userManager.AddToRoleAsync(currentLoggedInUser, role);
                
            }
            
            return View();
        }
    }
}
