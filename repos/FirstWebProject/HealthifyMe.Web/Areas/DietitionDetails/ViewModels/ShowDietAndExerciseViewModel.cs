using HealthifyMe.Web.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HealthifyMe.Web.Areas.DietitionDetails.ViewModels
{
    public class ShowDietAndExerciseViewModel
    {
        [Required]
        [Display(Name = "Dietition")]
        public int DietitionId { get; set; }

        public ICollection<DietChart> DietCharts { get; set; }
        public ICollection<Exercise> Exercises { get; set; }

    
    }

}
