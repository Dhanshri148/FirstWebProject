using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Healthifyme.Web.Models
{
    [Table(name: "DietCharts")]
    public class DietChart
    {
        [Key]
        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Display(Name = "Diet Chart ID")]
        public int DietChartId { get; set; }

        [Required]
        [Display(Name = "Food Receipe")]
        public string DietReceipeName { get; set; }

        [Required]
        [Display(Name = "Receipe Details")]
        public string ReceipeLink { get; set; }

        [Required]
        [Display(Name = "Image of the Foods")]
        public string DietImageUrl { get; set; }

        #region Navigation Properties to the DietCategory Model
        virtual public int? DietCategoryId { get; set; }

        [ForeignKey(nameof(DietChart.DietCategoryId))]
        public DietCategory DietCategory { get; set; }

        #endregion

        #region Navigation Properties to the Dietation Model
        public ICollection<Dietition> Dietitions { get; set; }

        #endregion
    }
}
