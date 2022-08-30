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
    public class DietCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DietCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dietitions/DietCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.DietCategories.ToListAsync());
        }

        // GET: Dietitions/DietCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietCategory = await _context.DietCategories
                .FirstOrDefaultAsync(m => m.DietCategoryId == id);
            if (dietCategory == null)
            {
                return NotFound();
            }

            return View(dietCategory);
        }

        // GET: Dietitions/DietCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dietitions/DietCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DietCategoryId,DietCategoryName")] DietCategory dietCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dietCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dietCategory);
        }

        // GET: Dietitions/DietCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietCategory = await _context.DietCategories.FindAsync(id);
            if (dietCategory == null)
            {
                return NotFound();
            }
            return View(dietCategory);
        }

        // POST: Dietitions/DietCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DietCategoryId,DietCategoryName")] DietCategory dietCategory)
        {
            if (id != dietCategory.DietCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dietCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DietCategoryExists(dietCategory.DietCategoryId))
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
            return View(dietCategory);
        }

        // GET: Dietitions/DietCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietCategory = await _context.DietCategories
                .FirstOrDefaultAsync(m => m.DietCategoryId == id);
            if (dietCategory == null)
            {
                return NotFound();
            }

            return View(dietCategory);
        }

        // POST: Dietitions/DietCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dietCategory = await _context.DietCategories.FindAsync(id);
            _context.DietCategories.Remove(dietCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DietCategoryExists(int id)
        {
            return _context.DietCategories.Any(e => e.DietCategoryId == id);
        }
    }
}
