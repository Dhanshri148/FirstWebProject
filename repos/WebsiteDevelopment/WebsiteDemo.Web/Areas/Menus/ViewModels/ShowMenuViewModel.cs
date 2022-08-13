using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebsiteDemo.Web.Models;

namespace WebsiteDemo.Web.Areas.Menus.ViewModels
{
    public class ShowMenuViewModel
    {
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public ICollection<Food> Foods { get; set; }
    }
}
