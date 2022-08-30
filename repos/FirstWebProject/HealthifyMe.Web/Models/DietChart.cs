using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace HealthifyMe.Web.Models
{
    [Table(name: "DietCharts")]
    public class DietChart
    {
        [Key]
        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Display(Name = "Diet Chart ID")]
        public int DietChartId { get; set; }

        [Required]
        [Display(Name = "Image of the Drinks")]
        public string DietImageUrl { get; set; }

        #region Navigation Properties to the Dietation Model
        public ICollection<Dietition> Dietitions { get; set; }

        #endregion
    }
}
