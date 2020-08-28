using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schoolwebsite.Data;
using schoolwebsite.Models;

namespace schoolwebsite.Controllers
{
    [Authorize]
    public class StudentdetailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public StudentdetailsController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public IActionResult Index()
        {
            var result = _context.Results.Include(m => m.Subjects).Include(m => m.Students).Include(m => m.Attendances).ToList();
            return View(result);
        }
        public IActionResult Createid(int id)
        {

            var output = _context.Studentdetails.Include(m=>m.Results).Include(m=>m.Students).Where(m => m.Students.id == id).ToList();
            //_context.SaveChanges();
            return Json(output);
        }
        public IActionResult Indextest()
        {
            var result = _context.Results.Include(m => m.Subjects).Include(m => m.Students).ToList();
            return Json(result);
        }
    }
}