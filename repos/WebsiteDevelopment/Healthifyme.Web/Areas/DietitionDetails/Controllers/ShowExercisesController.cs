using Healthifyme.Web.Areas.DietitionDetails.ViewModels;
using Healthifyme.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Healthifyme.Web.Areas.DietitionDetails.Controllers
{
    [Area("DietitionDetails")]
    public class ShowExercisesController : Controller
    {
         private readonly ApplicationDbContext _context;

        public ShowExercisesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<SelectListItem> exerciseCategories = new List<SelectListItem>();
            exerciseCategories.Add(new SelectListItem { Selected = true, Value = "", Text = "---select a category---" });
            exerciseCategories.AddRange(new SelectList(_context.ExerciseCategories, "ExerciseCategoryId", "ExerciseCategoryName"));
            ViewData["ExerciseCategoryId"] = exerciseCategories.ToArray();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("ExerciseCategoryId")] ShowExerciseViewModel model)
        {
            var exercises = _context.Exercises.Where(d => d.ExerciseCategoryId == model.ExerciseCategoryId);

            model.Exercises = exercises.ToList();

            ViewData["ExerciseCategoryId"] = new SelectList(_context.Categories, "ExerciseCategoryId", "ExerciseCategoryName");

            return View("Index", model);
        }

        public IActionResult AssignDietition(int? id, [Bind("ExerciseCategoryId", "ViewFees")] ShowExerciseViewModel model)
        {
            if (id.HasValue)
            {
                int exerciseId = id.Value;
            }
            return RedirectToAction("Index");
        }
    }
    
}
