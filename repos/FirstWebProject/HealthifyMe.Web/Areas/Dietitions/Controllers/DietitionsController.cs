using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthifyMe.Web.Data;
using HealthifyMe.Web.Models;

namespace HealthifyMe.Web.Areas.Dietitions.Controllers
{
    [Area("Dietitions")]
    public class DietitionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DietitionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dietitions/Dietitians
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dietitions.Include(d => d.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dietitions/Dietitians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietitian = await _context.Dietitions
                .Include(d => d.Category)
                .Include(d => d.Exercises)
                .Include(d => d.DietCharts)
                .FirstOrDefaultAsync(m => m.DietitionId == id);
            if (dietitian == null)
            {
                return NotFound();
            }

            return View(dietitian);
        }

        // GET: Dietitions/Dietitians/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            // ViewData["ExerciseId"] = new SelectList(_context.Categories, "ExerciseId", "ExerciseName");
            //ViewData["DietChartId"] = new SelectList(_context.Categories, "DietChartId", "ImageUrl");
            return View();
        }

        // POST: Dietitions/Dietitians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
                        [Bind("DietitionId,DietitionName,DietitionExperience,ContactNumber,ImageUrl,CategoryId,ExerciseId,DietChartId")]
                        Dietition dietitian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dietitian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", dietitian.CategoryId);
            ViewData["ExerciseId"] = new SelectList(_context.Categories, "ExerciseId", "ExerciseName", dietitian.ExerciseId);
            ViewData["DietChartId"] = new SelectList(_context.Categories, "DietChartId", "ImageUrl", dietitian.ImageUrl);
            return View(dietitian);
        }



        // GET: Dietitions/Dietitians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietitian = await _context.Dietitions.FindAsync(id);
            if (dietitian == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", dietitian.CategoryId);
            return View(dietitian);
        }

        // POST: Dietitions/Dietitians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DietitionId,DietitionName,DietitionExperience,ContactNumber,ImageUrl,CategoryId")] Dietition dietitian)
        {
            if (id != dietitian.DietitionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dietitian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DietitianExists(dietitian.DietitionId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", dietitian.CategoryId);
            return View(dietitian);
        }

        // GET: Dietitions/Dietitians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietitian = await _context.Dietitions
                .Include(d => d.Category)
                .FirstOrDefaultAsync(m => m.DietitionId == id);
            if (dietitian == null)
            {
                return NotFound();
            }

            return View(dietitian);
        }

        // POST: Dietitions/Dietitians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dietitian = await _context.Dietitions.FindAsync(id);
            _context.Dietitions.Remove(dietitian);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DietitianExists(int id)
        {
            return _context.Dietitions.Any(e => e.DietitionId == id);
        }
    }
}
