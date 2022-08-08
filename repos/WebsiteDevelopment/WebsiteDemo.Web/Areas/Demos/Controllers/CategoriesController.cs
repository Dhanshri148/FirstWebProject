using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebsiteDemo.Web.Data;
using WebsiteDemo.Web.Models;

namespace WebsiteDemo.Web.Areas.Demos.Controllers
{
    [Area("Demos")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(
            ApplicationDbContext context,
            ILogger<CategoriesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Demos/Categories
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("--------- Retrieved all categories from the database");
            return View(await _context.Category.ToListAsync());
        }

        // GET: Demos/Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Demos/Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Demos/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryName")] Category categoryInputModel)
        {

            if (ModelState.IsValid)
            {
                categoryInputModel.CategoryName = categoryInputModel.CategoryName.Trim();

                bool isDuplicateFound
                    = _context.Category.Any(c => c.CategoryName == categoryInputModel.CategoryName);

                if (isDuplicateFound)
                {
                    ModelState.AddModelError("CategoryName", "Duplicate! Another category with same name exists");
                }
                else
                {
                    _context.Add(categoryInputModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(categoryInputModel);
        }

        // GET: Demos/Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Demos/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("CategoryId,CategoryName")] Category categoryInputModel)
        {
            if (id != categoryInputModel.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                categoryInputModel.CategoryName = categoryInputModel.CategoryName.Trim();

                bool isDuplicateFound
                    = _context.Category.Any(c => c.CategoryName == categoryInputModel.CategoryName
                                                    && c.CategoryId != categoryInputModel.CategoryId);
                if (isDuplicateFound)
                {
                    ModelState.AddModelError("CategoryName", "A duplicate category was found!");
                }
                else
                {
                    try
                    {
                        _context.Update(categoryInputModel);

                        await _context.SaveChangesAsync();

                        return RedirectToAction(nameof(Index));

                    }

                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CategoryExists(categoryInputModel.CategoryId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
            return View(categoryInputModel);
        }

        // GET: Demos/Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Demos/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
