using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomePage.Web.Models
{
    [Table(name: "Categories")]
    public class Category
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Category ID")]
        public int CategoryId { get; set;}


        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name ="Name of the Category")]
        public string CategoryName { get; set; }

        #region Navigation Properties to the Product Model
        public ICollection<Product> Products { get; set; }

        #endregion


    }
}
