using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthifyMe.Web.Models
{
    [Table(name:"Dietitions")]
    public class Dietition
    {
        [Key]
        [Display(Name = "Dietition ID")]
        public int DietitionId { get; set; }

        [Required(ErrorMessage = "{0} cannot be Empty")]
        [Display(Name = "Name of the Dietition")]
        [Column(TypeName = "varchar(100)")]
        public string DietitionName { get; set; }

        [Required]
        [Display(Name = "Dietition Experience")]
        public int DietitionExperience { get; set; }

        [Required]
        [Display(Name = "Contact Number of Dietition")]
        public long ContactNumber { get; set; }

        [StringLength(120)]
        virtual public string ImageUrl { get; set; } = null;

        [Required]
        [Display(Name = "Fees of the Dietation")]
        public int Fees { get; set; }

        #region Navigation Properties to the Category Model
        virtual public int CategoryId { get; set; }

        [ForeignKey(nameof(Dietition.CategoryId))]
        public Category Category { get; set; }

        #endregion

        #region Navigation Properties to the Exercise Model
        virtual public int? ExerciseId { get; set; }

        [ForeignKey(nameof(Dietition.ExerciseId))]
        public Exercise Exercises { get; set; }

        #endregion

        #region Navigation Properties to the Exercise Model
        virtual public int? DietChartId { get; set; }

        [ForeignKey(nameof(Dietition.DietChartId))]
        public DietChart DietCharts { get; set; }

        #endregion



    }
}
