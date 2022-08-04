using HomePage.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace HomePage.Web.Areas.Products.ViewModels
{
    public class ProductViewModel : Product
    {
        [Display(Name = "Product ID")]
        public override int ProductId 
        { 
            get
            {
                return base.ProductId;
            }
            set
            {
                base.ProductId = value;
            }
        }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "{0} cannot be empty")]
        [MinLength(2, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(100, ErrorMessage = "{0} can have a maximum of {1} characters")]
        public override string ProductName 
        {
            get => base.ProductName;
            set => base.ProductName = value;
        }

        [Display(Name ="Is Available?")]
        public override bool IsAvailable
        {
            get => base.IsAvailable;
            set => base.IsAvailable = value;
        }

        [Display(Name = "Category")]
        public override int CategoryId
        {
            get => base.CategoryId;
            set => base.CategoryId = value;
        }

    }
}
