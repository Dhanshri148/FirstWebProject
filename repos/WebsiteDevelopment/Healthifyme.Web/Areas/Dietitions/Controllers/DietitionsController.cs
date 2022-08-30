using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Healthifyme.Web.Data;
using Healthifyme.Web.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Healthifyme.Web.Areas.Dietitions.Controllers
{
    [Area("Dietitions")]
    [Authorize(Roles = "AppAdmin,AppDietition")]
    public class DietitionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DietitionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Dietitions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dietitions.Include(d => d.Category).Include(d => d.DietCharts).Include(d => d.Exercises);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Index1()
        {
            var applicationDbContext = _context.Dietitions.Include(d => d.Category).Include(d => d.DietCharts).Include(d => d.Exercises);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Dietitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietition = await _context.Dietitions
                .Include(d => d.Category)
                .Include(d => d.DietCharts)
                .Include(d => d.Exercises)
                .FirstOrDefaultAsync(m => m.DietitionId == id);
            if (dietition == null)
            {
                return NotFound();
            }

            return View(dietition);
        }

        // GET: Admin/Dietitions/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["DietChartId"] = new SelectList(_context.DietCharts, "DietChartId", "DietReceipeName");
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "ExerciseId", "ExerciseName");
            return View();
        }

        // POST: Admin/Dietitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DietitionId,DietitionName,DietitionExperience,ContactNumber,ImageUrl,Fees,CategoryId,ExerciseId,DietChartId")] Dietition dietition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dietition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", dietition.CategoryId);
            ViewData["DietChartId"] = new SelectList(_context.DietCharts, "DietChartId", "DietReceipeName", dietition.DietChartId);
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "ExerciseId", "ExerciseId", dietition.ExerciseId);
            return View(dietition);
        }

        // GET: Admin/Dietitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietition = await _context.Dietitions.FindAsync(id);
            if (dietition == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", dietition.CategoryId);
            ViewData["DietChartId"] = new SelectList(_context.DietCharts, "DietChartId", "DietReceipeName", dietition.DietChartId);
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "ExerciseId", "ExerciseId", dietition.ExerciseId);
            return View(dietition);
        }

        // POST: Admin/Dietitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DietitionId,DietitionName,DietitionExperience,ContactNumber,ImageUrl,Fees,CategoryId,ExerciseId,DietChartId")] Dietition dietition)
        {
            if (id != dietition.DietitionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dietition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DietitionExists(dietition.DietitionId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", dietition.CategoryId);
            ViewData["DietChartId"] = new SelectList(_context.DietCharts, "DietChartId", "DietReceipeName", dietition.DietChartId);
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "ExerciseId", "ExerciseId", dietition.ExerciseId);
            return View(dietition);
        }

        // GET: Admin/Dietitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietition = await _context.Dietitions
                .Include(d => d.Category)
                .Include(d => d.DietCharts)
                .Include(d => d.Exercises)
                .FirstOrDefaultAsync(m => m.DietitionId == id);
            if (dietition == null)
            {
                return NotFound();
            }

            return View(dietition);
        }

        // POST: Admin/Dietitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dietition = await _context.Dietitions.FindAsync(id);
            _context.Dietitions.Remove(dietition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DietitionExists(int id)
        {
            return _context.Dietitions.Any(e => e.DietitionId == id);
        }
    }
}
