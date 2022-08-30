using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthifyMe.Web.Models
{
    [Table(name: "Exercises")]
    public class Exercise
    {
        [Key]
        [Required]
        [Display(Name = "Exercise Id")]
        public int ExerciseId { get; set; }

        public string ExerciseName { get; set; }

        #region Navigation Properties to the ExerciseCategory Model
        virtual public int ExerciseCategoryId { get; set; }

        [ForeignKey(nameof(Exercise.ExerciseCategoryId))]
        public ExerciseCategory ExerciseCategory { get; set; }

        #endregion

        #region Navigation Properties to the Dietation Model
        public ICollection<Dietition> Dietitions { get; set; }

        #endregion
    }
}
