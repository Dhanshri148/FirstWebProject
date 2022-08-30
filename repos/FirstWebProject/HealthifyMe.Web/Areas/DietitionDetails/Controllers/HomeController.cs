using HealthifyMe.Web.Areas.DietitionDetails.ViewModels;
using HealthifyMe.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace HealthifyMe.Web.Areas.DietitionDetails.Controllers
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
