using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteDemo.Web.Models
{
    [Table(name:"Customers")]
    public class Customer
    {

        [Key]
        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Address of the Customer")]
        public string CustomerAddress { get; set; }

        #region Navigation Properties to the OrderDetails Model
        public ICollection<Order> Orders { get; set; }

        #endregion


    }
}
