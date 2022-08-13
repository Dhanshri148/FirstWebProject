using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteDemo.Web.Models
{
    [Table(name:"Orders")]
    public class Order
    {
        [Key]
        virtual public int OrderId { get; set; }

        [Required]
        [StringLength(50)]
        virtual public string OrderName { get; set; }

        [Required]
        virtual public string OrderStatus { get; set; }

        #region Navigation Properties to the Order Details Model
        public ICollection<OrderDetail> OrderDetails { get; set; }

        #endregion

        #region Navigation Properties to the Customer Model

        public int CustomerId { get; set; }

        [ForeignKey(nameof(Order.CustomerId))]
        public Customer Customer { get; set; }

        #endregion

    }
}
