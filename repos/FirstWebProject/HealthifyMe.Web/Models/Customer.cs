using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthifyMe.Web.Models
{
    [Table(name: "Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "{0} cannot be Empty!")]
        [Display(Name = "Name of the Customer")]
        public string CustomerName { get; set; }

        [Display(Name = "Address of the Customer")]
        [Column(TypeName = "varchar(100)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} caanot be empty!")]
        [Display(Name = "Phone Number of the Customer")]
        public long ContactNumber { get; set; }


    }
}
