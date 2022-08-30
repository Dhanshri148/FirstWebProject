using Healthifyme.Web.Areas.DietitionDetails.ViewModels;
using Healthifyme.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthifyme.Web.Areas.DietitionDetails.Controllers
{
    [Area("DietitionDetails")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem {  Selected = true, Value = "", Text = "---select a category---" });
            categories.AddRange(new SelectList(_context.Categories, "CategoryId", "CategoryName"));
            ViewData["CategoryId"] = categories.ToArray();

            return View();
        }
        public async Task<IActionResult> Index1()
        {
            var applicationDbContext = _context.Exercises.Include(e => e.ExerciseCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Index2()
        {
            var applicationDbContext = _context.Exercises.Include(e => e.ExerciseCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Index3()
        {
            var applicationDbContext = _context.Customers.Include(c => c.Dietition).Include(c => c.Payment);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Exercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercises
                .Include(e => e.ExerciseCategory)
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("CategoryId")] ShowDietitionViewModel model)
        {
            var dietitions = _context.Dietitions.Where(d => d.CategoryId == model.CategoryId);

            model.Dietitions = dietitions.ToList();

            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");

            return View("Index",model);
        }

        public IActionResult AssignDietition(int? id, [Bind("CategoryId","ViewFees")] ShowDietitionViewModel model)
        {
            if(id.HasValue)
            {
                int dietitionId = id.Value;
            }
            return RedirectToAction("Index");
        }
    }
}
