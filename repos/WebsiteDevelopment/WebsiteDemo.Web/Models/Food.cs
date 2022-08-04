using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteDemo.Web.Models
{
    [Table(name:"Foods")]
    public class Food
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int FoodId { get; set; }

        [Required]
        [StringLength(50)]
        virtual public string FoodName { get; set; }

        [Required]
        [DefaultValue(false)]
        virtual public bool IsAvailable { get; set; }


        #region Navigation Properties to the Category Model
        virtual public int CategoryId { get; set; }

        [ForeignKey(nameof(Food.CategoryId))]
        public Category Category { get; set; }

        #endregion
    }
}
