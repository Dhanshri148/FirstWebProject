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
    [Authorize(Roles = "AppAdmin,AppDietition,AppUser")]
    public class DietChartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DietChartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dietitions/DietCharts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DietCharts.Include(d => d.DietCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dietitions/DietCharts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietChart = await _context.DietCharts
                .Include(d => d.DietCategory)
                .FirstOrDefaultAsync(m => m.DietChartId == id);
            if (dietChart == null)
            {
                return NotFound();
            }

            return View(dietChart);
        }

        // GET: Dietitions/DietCharts/Create
        public IActionResult Create()
        {
            ViewData["DietCategoryId"] = new SelectList(_context.DietCategories, "DietCategoryId", "DietCategoryName");
            return View();
        }

        // POST: Dietitions/DietCharts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DietChartId,DietReceipeName,ReceipeLink,DietImageUrl,DietCategoryId")] DietChart dietChart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dietChart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DietCategoryId"] = new SelectList(_context.DietCategories, "DietCategoryId", "DietCategoryName", dietChart.DietCategoryId);
            return View(dietChart);
        }

        // GET: Dietitions/DietCharts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietChart = await _context.DietCharts.FindAsync(id);
            if (dietChart == null)
            {
                return NotFound();
            }
            ViewData["DietCategoryId"] = new SelectList(_context.DietCategories, "DietCategoryId", "DietCategoryName", dietChart.DietCategoryId);
            return View(dietChart);
        }

        // POST: Dietitions/DietCharts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DietChartId,DietReceipeName,ReceipeLink,DietImageUrl,DietCategoryId")] DietChart dietChart)
        {
            if (id != dietChart.DietChartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dietChart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DietChartExists(dietChart.DietChartId))
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
            ViewData["DietCategoryId"] = new SelectList(_context.DietCategories, "DietCategoryId", "DietCategoryName", dietChart.DietCategoryId);
            return View(dietChart);
        }

        // GET: Dietitions/DietCharts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietChart = await _context.DietCharts
                .Include(d => d.DietCategory)
                .FirstOrDefaultAsync(m => m.DietChartId == id);
            if (dietChart == null)
            {
                return NotFound();
            }

            return View(dietChart);
        }

        // POST: Dietitions/DietCharts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dietChart = await _context.DietCharts.FindAsync(id);
            _context.DietCharts.Remove(dietChart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DietChartExists(int id)
        {
            return _context.DietCharts.Any(e => e.DietChartId == id);
        }
    }
}
