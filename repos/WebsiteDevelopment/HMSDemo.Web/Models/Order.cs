using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMSDemo.Web.Models
{
    [Table(name: "Orders")]
    public class Order
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderName { get; set; }


        public string OrderStatus { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        #region Navigation Properties to the Customer Model

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(Order.CustomerId))]
        public Customer Customer { get; set; }
        //public object Customers { get; internal set; }

        #endregion

    }
}
