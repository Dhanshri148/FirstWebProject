using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healthifyme.Web.Models
{
    [Table(name: "Exercises")]
    public class Exercise
    {
        [Key]
        [Required]
        [Display(Name = "Exercise Id")]
        public int ExerciseId { get; set; }

        public string ExerciseName { get; set; }

        [Required]
        [Display(Name = "Description of the Exercise")]
        [Column(TypeName = "varchar(500)")]
        public string ExerciseDescription { get; set; }

        [Display(Name = "Image of the Exercise")]
        public string ImageUrl { get; set; }

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
