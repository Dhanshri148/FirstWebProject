using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteDemo.Web.Models
{
    [Table(name:"Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderName { get; set; }

        [Required]
        public string OrderStatus { get; set; }

        #region Navigation Properties to the Food Model

        [Required]
        public int FoodId { get; set; }

        [ForeignKey(nameof(Order.FoodId))]
        public Food Food { get; set; }

        #endregion

        #region Navigation Properties to the Customer Model
        public ICollection<Customer> Customers { get; set; }

        #endregion  

    }
}
