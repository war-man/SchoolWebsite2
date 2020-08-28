using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using schoolwebsite.Data;
using schoolwebsite.Models;

namespace schoolwebsite.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly UserManager<IdentityUser> usermanager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext db;
        public UserRoleController(UserManager<IdentityUser> usermanager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db) 
        {
            this.usermanager = usermanager;
            this.roleManager = roleManager;
            this.db = db;
        }
        public IActionResult Index()
        {
            
            var alldata = roleManager.Roles.ToList();
            return Json(alldata);
        }
        public IActionResult Create() 
        {
            ViewData["UserId"] = new SelectList(usermanager.Users.ToList(), "Id", "UserName");
            ViewData["RoleId"] = new SelectList(roleManager.Roles.ToList(), "Name", "Name");

            return View();
        } 

        [HttpPost]
        public async Task<IActionResult> Create(UserRole role)
        {
            if (ModelState.IsValid)
            {


                var user = usermanager.Users.FirstOrDefault(c => c.Id == role.UserId);
                var Role = await usermanager.AddToRoleAsync(user, role.RoleId);
                db.UserRole.Add(role);
                if (Role.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }

    }
}