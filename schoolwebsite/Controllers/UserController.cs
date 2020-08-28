using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace schoolwebsite.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> usermanager;


        public UserController(UserManager<IdentityUser> usermanager)
        {
            this.usermanager = usermanager;
        }
        public IActionResult Index()
        {
            var result = usermanager.Users.ToList();
            return View (result);
        }

    
    }
}