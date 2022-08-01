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
        public int BookId { get; set; }

        [Required]
        [StringLength(100)]
        public string BookTitle { get; set; }

        [Required]
        [DefaultValue(1)]
        public short NumberOfCopies { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsEnabled { get; set; }
    }
}
