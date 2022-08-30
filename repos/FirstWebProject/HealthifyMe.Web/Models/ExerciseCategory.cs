using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthifyMe.Web.Models
{
    [Table(name: "ExerciseCategories")]
    public class ExerciseCategory
    {
        public int ExerciseCategoryId { get; set; }

        public string ExerciseCategoryName { get; set; }

        #region Navigation Properties to the Exercise Mode
        public ICollection<Exercise> Exercise { get; set; }

        #endregion

    }
}
