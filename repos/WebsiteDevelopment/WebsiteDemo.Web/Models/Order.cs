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
        virtual public int OrderId { get; set; }

        [Required]
        [StringLength(50)]
        virtual public string OrderName { get; set; }

        [Required]
        virtual public string OrderStatus { get; set; }

        #region Navigation Properties to the Food Model

        [Required]
        virtual public int FoodId { get; set; }

        [ForeignKey(nameof(Order.FoodId))]
        public Food Food { get; set; }

        #endregion

        #region Navigation Properties to the Customer Model
        public ICollection<Customer> Customers { get; set; }

        #endregion  

    }
}
