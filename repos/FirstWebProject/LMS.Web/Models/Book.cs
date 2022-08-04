using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Web.Models
{
    [Table(name: "Books")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        virtual public int BookId { get; set; }

        [Required]
        [StringLength(100)]
        virtual public string BookTitle { get; set; }

        [Required]
        [DefaultValue(1)]
        virtual public short NumberOfCopies { get; set; }

        [Required]
        [DefaultValue(false)]
        virtual public bool IsEnabled { get; set; }

        #region Navigation Properties to the Category Model
        virtual public int CategoryId { get; set; }

        [ForeignKey(nameof(Book.CategoryId))]
        public Category Category { get; set; }

        #endregion
    }
}
