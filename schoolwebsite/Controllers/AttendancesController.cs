using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using schoolwebsite.Data;
using schoolwebsite.Models;

namespace schoolwebsite.Controllers
{
    [Authorize]
    public class AttendancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController(ApplicationDbContext context)
        
        {
                _context = context;
        }
            public IActionResult Index()
        {
            
            return View();
        }
        

        
        public IActionResult Indexdata(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _context.Attendances.Add(attendance);
                _context.SaveChanges();
                //return RedirectToAction(nameof(Success));   
            }


            var result = _context.Attendances.ToList();
            return Json(result);
            
        }

        public IActionResult Datashow()
        {
            var result = _context.Attendances.Include(m=>m.Students).OrderBy(n=>n.Students.Name).ToList();
            return View (result);
        }

        public IActionResult Jsonshow()
        {
            var result = _context.Attendances.Include(m => m.Students).OrderBy(n => n.Students.Name).ToList();
            return Json(result);
        }
        public IActionResult Index4()
        {
            var result = _context.Students.ToList();
            return Json (result);
        }
        //just for test purpose to see what data is coming
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var teachers = await _context.Teachers
        //        .FirstOrDefaultAsync(m => m.id == id);
        //    if (teachers == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(teachers);
        //}

        // POST: Teachers/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Datashow));
            
        }



        public IActionResult Individualjquery(int classinfo, int roll)
        {
            ViewData["individualid"] = new SelectList(_context.Students.ToList(), "id", "classinfo");
            var result = _context.Attendances.Include(m => m.Students).Where(m => m.Students.classinfo == classinfo).Where(m=>m.Students.roll==roll).ToList();
            return View(result);
        }
        public IActionResult Index2()
        {
            
            return View ();
        }
        public IActionResult Index3()
        {
            ViewData["nameofstudents"] = new SelectList(_context.Students.ToList(), "id", "Name");
            return View();
        }
        public IActionResult Datainfo(int userdata)
        {
            //string ID = userdata.ToString();
            var result = _context.Attendances.Include(m=>m.Students).Where(m => m.Students.id == userdata).OrderByDescending(m=>m.Year).ToList();
            return Json(result);
        }

        public IActionResult Searchbox(int classinfo, int roll, string section )
        {   
            
            var result101 = _context.Attendances.Include(m => m.Students).Where(m => m.Students.classinfo == classinfo);
            var result102 = result101.Where(m => m.Students.roll == roll);
            var result = result102.Where(m => m.Students.section == section).ToList();
            return Json (result);
        }

        //this action is only for testing purpose

        public IActionResult AttendancesData()
        {
            var result = _context.Attendances.ToList();
            return Json(result);
        }
        public IActionResult Deleteall()
        {
            var result = _context.Attendances.Include(m=>m.Students).ToList();


            
            foreach (var res in result)
                _context.Attendances.Remove(res);
            _context.SaveChanges();
           
            return Json(1);
        }

    }
}