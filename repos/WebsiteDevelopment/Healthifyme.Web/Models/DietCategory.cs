using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healthifyme.Web.Models
{
    [Table(name: "DietCategories")]
    public class DietCategory
    {
        [Key]
        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Display(Name = "Diet Category ID")]
        public int DietCategoryId { get; set; }

        [Required]
        [Display(Name = "Name of the Diet Category")]
        public string DietCategoryName { get; set; }

        #region Properties to the DietChart Model

        public ICollection<DietChart> DietCharts { get; set; }

        #endregion


    }
}
