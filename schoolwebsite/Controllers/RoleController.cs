using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using schoolwebsite.Models;

namespace schoolwebsite.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var allroles = roleManager.Roles.ToList();
            return View(allroles);
        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            var roles = await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Delete(string roleid)
        {
            var roles = await roleManager.FindByIdAsync(roleid);
           
            await roleManager.DeleteAsync(roles);
                     
            return RedirectToAction("Index");

            
        }
    }
}