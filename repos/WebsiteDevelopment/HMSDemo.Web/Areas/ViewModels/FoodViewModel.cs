using System.ComponentModel.DataAnnotations;
using HMSDemo.Web.Models;

namespace WebsiteDemo.Web.Areas.Demos.ViewModels
{
    public class FoodViewModel : Food
    {
        [Display(Name = "Food Item Id")]
        public override int FoodId
        {
            get
            {
                return base.FoodId;
            }
            set
            {
                base.FoodId = value;
            }
        }

        [Display(Name = "Name of the Food")]
        [Required(ErrorMessage = "{0} cannot be Empty")]
        
        public override string FoodName
        {
            get => base.FoodName; 
            set => base.FoodName = value; 
        }

        [Display(Name ="Is Food Available?")]
        public override bool IsAvailable 
        {
            get => base.IsAvailable; 
            set => base.IsAvailable = value;
        }

        [Display(Name ="Category")]
        public override int CategoryId 
        {
            get => base.CategoryId;
            set => base.CategoryId = value;
        }

        [Display(Name = "Photo of the Food")]
        public override string ImageUrl
        {
            get => base.ImageUrl;
            set => base.ImageUrl = value;
        }

        [Display(Name = "Price of Food")]
        public override double FoodPrice
        {
                get => base.FoodPrice;      
                set => base.FoodPrice = value;
        }
    }
}
