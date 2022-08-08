using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebsiteDemo.Web.Areas.Demos.ViewModels;
using WebsiteDemo.Web.Data;
using WebsiteDemo.Web.Models;

namespace WebsiteDemo.Web.Areas.Demos.Controllers
{
    [Area("Demos")]
    public class FoodsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public readonly ILogger<FoodsController> _logger;

        public FoodsController(
            ApplicationDbContext context,
            ILogger<FoodsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Demos/Foods
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("--------------Retrieve details of the Foods along with the Associated Category from  the database");

            var viewmodel = await _context.Foods
                                                .Include(f => f.Category)
                                                .ToListAsync();

            return View(viewmodel);
        }

        // GET: Demos/Foods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.Foods
                .Include(f => f.Category)
                .Include(f => f.Orders)
                .FirstOrDefaultAsync(m => m.FoodId == id);
            if (food == null)
            {
                return NotFound();
            }

            FoodViewModel viewModel = new FoodViewModel()
            {
                FoodId = food.FoodId,
                FoodName = food.FoodName,
                FoodPrice = food.FoodPrice,
                IsAvailable = food.IsAvailable,

                CategoryId = food.CategoryId,
                Category = food.Category,

                Orders = food.Orders
            };

            return View(viewModel);
        }

        // GET: Demos/Foods/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Demos/Foods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodId,FoodName,IsAvailable,CategoryId,ImageUrl,FoodPrice")] Food food)
        {
            if (ModelState.IsValid)
            {
                _context.Add(food);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", food.CategoryId);
            return View(food);
        }

        // GET: Demos/Foods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", food.CategoryId);

            var foodViewModel = new FoodViewModel()
            {
                FoodId = food.FoodId,
                FoodName = food.FoodName,
                FoodPrice = food.FoodPrice,
                IsAvailable = food.IsAvailable,
                CategoryId = food.CategoryId,
                Category = food.Category
            };

            return View(foodViewModel);
        }

        // POST: Demos/Foods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodId,FoodName,IsAvailable,CategoryId,ImageUrl,FoodPrice")] Food food)
        {
            if (id != food.FoodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(food);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodExists(food.FoodId))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", food.CategoryId);
            return View(food);
        }

        // GET: Demos/Foods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.Foods
                .Include(f => f.Category)
                .FirstOrDefaultAsync(m => m.FoodId == id);
            if (food == null)
            {
                return NotFound();
            }

            var foodViewModel = new FoodViewModel()
            {
                FoodId = food.FoodId,
                FoodName = food.FoodName,
                FoodPrice = food.FoodPrice,
                IsAvailable = food.IsAvailable,
                CategoryId = food.CategoryId,
                Category = food.Category
            };

            return View(foodViewModel);
        }

        // POST: Demos/Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodExists(int id)
        {
            return _context.Foods.Any(e => e.FoodId == id);
        }
    }
}
