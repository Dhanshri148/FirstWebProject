using HealthifyMe.Web.Areas.DietitionDetails.ViewModels;
using HealthifyMe.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace HealthifyMe.Web.Areas.DietitionDetails.Controllers
{
    public class DietAndExerciseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DietAndExerciseController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<SelectListItem> exercises = new List<SelectListItem>();
            exercises.Add(new SelectListItem { Selected = true, Value = "", Text = "---select a category---" });
            exercises.AddRange(new SelectList(_context.Exercises, "ExerciseId", "ExerciseName"));
            ViewData["ExerciseId"] = exercises.ToArray();

            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Index([Bind("ExerciseId")] ShowDietAndExerciseViewModel model)
        //{
        //    var dietitions = _context.Dietitions.Where(d => d.ExerciseId == model.DietitionId);

        //    model.Exercises = exercises.ToList();

        //    ViewData["ExerciseId"] = new SelectList(_context.Exercises, "ExerciseId", "ExerciseName");

        //    return View("Index", model);
        //}

        public IActionResult AssignExercise(int? id, [Bind("exerciseId", "ViewFees")] ShowDietitionViewModel model)
        {
            if (id.HasValue)
            {
                int exerciseId = id.Value;
            }
            return RedirectToAction("Index");
        }
    }
    
}
