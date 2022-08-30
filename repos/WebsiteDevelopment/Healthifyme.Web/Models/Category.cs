using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healthifyme.Web.Models
{
    [Table(name:"Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "{0} cannot be Empty")]
        [Display(Name = "Name of the Category")]
        [Column(TypeName = "varchar(100)")]
        public string CategoryName { get; set; }

        #region Navigation Properties to the Dietition Model

        public ICollection<Dietition> Dietitians { get; set; }

        #endregion


    }
}
