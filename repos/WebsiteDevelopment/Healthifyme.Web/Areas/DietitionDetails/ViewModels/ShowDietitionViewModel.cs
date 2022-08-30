using Healthifyme.Web.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Healthifyme.Web.Areas.DietitionDetails.ViewModels
{
    public class ShowDietitionViewModel 
    {
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public ICollection<Dietition> Dietitions { get; set; }
        
        public int? Fee { get; set; }
    }
}
