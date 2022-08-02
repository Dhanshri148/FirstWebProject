using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomePage.Web.Models
{
    [Table(name: "Products")]
    public class Product
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsAvailable { get; set; }


        #region Navigation Properties to the Category Model
        public int CategoryId { get; set; }

        [ForeignKey(nameof(Product.CategoryId))]
        public Category Category { get; set; }

        #endregion
    }
}
