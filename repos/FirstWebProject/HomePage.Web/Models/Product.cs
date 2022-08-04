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
        virtual public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        virtual public string ProductName { get; set; }

        [Required]
        [DefaultValue(false)]
        virtual public bool IsAvailable { get; set; }


        #region Navigation Properties to the Category Model
        virtual public int CategoryId { get; set; }

        [ForeignKey(nameof(Product.CategoryId))]
        public Category Category { get; set; }

        #endregion
    }
}
