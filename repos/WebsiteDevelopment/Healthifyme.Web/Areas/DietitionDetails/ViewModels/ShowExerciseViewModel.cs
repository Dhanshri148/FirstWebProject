using Healthifyme.Web.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Healthifyme.Web.Areas.DietitionDetails.ViewModels
{
    public class ShowExerciseViewModel
    {
        [Required]
        [Display(Name = "Exercise Category")]
        public int ExerciseCategoryId { get; set; }

        public ICollection<Exercise> Exercises { get; set; }

        public string Details { get; set; }
    }
}
