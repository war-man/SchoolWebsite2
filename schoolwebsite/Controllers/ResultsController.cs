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
using SQLitePCL;

namespace schoolwebsite.Controllers
{
    [Authorize]
    public class ResultsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResultsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Results
        public async Task<IActionResult> Index()
        {
            return View(await _context.Results.Include(m=>m.Students).ToListAsync());
        }

        // GET: Results/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var results = await _context.Results
                .FirstOrDefaultAsync(m => m.id == id);
            if (results == null)
            {
                return NotFound();
            }

            return View(results);
        }

        // GET: Results/Create
        public IActionResult Create()
        {
            ViewData["Studentsid"] = new SelectList(_context.Students.ToList(), "id", "Name");
            ViewData["Subjectsid"] = new SelectList(_context.Subjects.ToList(), "id", "Class");
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Studentsid,year,Subjectsid,Result1,Result2,Result3,Result4,Result5,Result6,Result7,Result8,Result9,Result10,Result11,Result12")] Results results)
        {
            if (ModelState.IsValid)
            {
                _context.Add(results);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Studentsid"] = new SelectList(_context.Students.ToList(), "id", "Name",results.Studentsid);
            return View(results);
        }

        // GET: Results/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var results = await _context.Results.FindAsync(id);
            if (results == null)
            {
                return NotFound();
            }
            return View(results);
        }

        // POST: Results/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Studentsid,Class,Result1,Result2,Result3,Result4,Result5,Result6,Result7,Result8,Result9,Result10,Result11,Result12")] Results results)
        {
            if (id != results.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(results);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultsExists(results.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(results);
        }

        // GET: Results/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var results = await _context.Results
                .FirstOrDefaultAsync(m => m.id == id);
            if (results == null)
            {
                return NotFound();
            }

            return View(results);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var results = await _context.Results.FindAsync(id);
            _context.Results.Remove(results);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Datatest(int id=1)
        {
            //var result = _context.Results.Include(m => m.Students).Where(m => m.Students.id == id).ToList();
            var result = _context.Results.Include(m=>m.Students).Where(m => m.Students.id == id).ToList();
            return Json(result);
        }

        public IActionResult Datainfo (int userdata)
        {
            //string ID = userdata.ToString();
            var result = _context.Subjects.Where(m => m.id == userdata).ToList();
            return Json(result);
        }
            
        private bool ResultsExists(int id)
        {
            return _context.Results.Any(e => e.id == id);
        }
    }
}
