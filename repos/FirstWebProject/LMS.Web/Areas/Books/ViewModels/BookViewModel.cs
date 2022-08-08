using LMS.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace LMS.Web.Areas.Books.ViewModels
{
    public class BookViewModel : Book
    {
        [Display(Name = "Book ID")]
        public override int BookId
        {
            get
            {
                return base.BookId;
            }
            set
            {
                base.BookId = value;
            }
        }

        [Display(Name = "Name of the Book")]
        [Required(ErrorMessage = "{0} Cannot be Empty")]
        [MinLength(2, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(100,ErrorMessage ="{0} can have maximum of {1} characters")]
        public override string BookTitle 
        {
            get => base.BookTitle;
            set => base.BookTitle = value;
        }

        [Display(Name ="Number of Copies")]
        public override short NumberOfCopies 
        {
            get => base.NumberOfCopies; 
            set => base.NumberOfCopies = value; 
        }

        [Display(Name ="Is Enabled?")]
        public override bool IsEnabled 
        {
            get => base.IsEnabled;
            set => base.IsEnabled = value;
        }

        [Display(Name ="Category")]
        public override int CategoryId 
        {
            get => base.CategoryId;
            set => base.CategoryId = value;
        }

        [Display(Name ="Cover Photo of the Book")]
        public override string ImageUrl
        {
            get => base.ImageUrl;
            set => base.ImageUrl = value;
        }

    }
}
