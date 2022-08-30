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
    public class ExerciseCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExerciseCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dietitions/ExerciseCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExerciseCategories.ToListAsync());
        }

        // GET: Dietitions/ExerciseCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseCategory = await _context.ExerciseCategories
                .FirstOrDefaultAsync(m => m.ExerciseCategoryId == id);
            if (exerciseCategory == null)
            {
                return NotFound();
            }

            return View(exerciseCategory);
        }

        // GET: Dietitions/ExerciseCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dietitions/ExerciseCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciseCategoryId,ExerciseCategoryName")] ExerciseCategory exerciseCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exerciseCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exerciseCategory);
        }

        // GET: Dietitions/ExerciseCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseCategory = await _context.ExerciseCategories.FindAsync(id);
            if (exerciseCategory == null)
            {
                return NotFound();
            }
            return View(exerciseCategory);
        }

        // POST: Dietitions/ExerciseCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciseCategoryId,ExerciseCategoryName")] ExerciseCategory exerciseCategory)
        {
            if (id != exerciseCategory.ExerciseCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exerciseCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseCategoryExists(exerciseCategory.ExerciseCategoryId))
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
            return View(exerciseCategory);
        }

        // GET: Dietitions/ExerciseCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseCategory = await _context.ExerciseCategories
                .FirstOrDefaultAsync(m => m.ExerciseCategoryId == id);
            if (exerciseCategory == null)
            {
                return NotFound();
            }

            return View(exerciseCategory);
        }

        // POST: Dietitions/ExerciseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exerciseCategory = await _context.ExerciseCategories.FindAsync(id);
            _context.ExerciseCategories.Remove(exerciseCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseCategoryExists(int id)
        {
            return _context.ExerciseCategories.Any(e => e.ExerciseCategoryId == id);
        }
    }
}
