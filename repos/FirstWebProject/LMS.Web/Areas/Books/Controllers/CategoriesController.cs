using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS.Web.Data;
using LMS.Web.Models;
using Microsoft.Extensions.Logging;

namespace LMS.Web.Areas.Books.Controllers
{
    [Area("Books")]
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

        // GET: Books/Categories
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("--------- Retrieved all categories from the database");
            return View(await _context.Categories.ToListAsync());
        }

        // GET: Books/Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Books/Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryName")] Category categoryModel)
        {
            if (ModelState.IsValid)
            {
                categoryModel.CategoryName = categoryModel.CategoryName.Trim();

                bool isDuplicateFound
                    = _context.Categories.Any(c => c.CategoryName == categoryModel.CategoryName);

                if (isDuplicateFound)
                {
                    ModelState.AddModelError("CategoryName", "Duplicate! Another category with same name exists");
                }
                else {
                    _context.Add(categoryModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(categoryModel);
        }

        // GET: Books/Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Books/Categories/Edit/5
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
                    = _context.Categories.Any(c => c.CategoryName == categoryInputModel.CategoryName
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

        // GET: Books/Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .SingleOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Books/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}
