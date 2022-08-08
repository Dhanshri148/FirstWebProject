using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Web.Models
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

        [Required]
        public string OrderStatus { get; set; }

        [Required]
        [Display(Name = "Food Order Date")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Food Quantity")]
        public int Quantity { get; set; }


        #region Navigation Properties to the Food Model

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(Order.CustomerId))]
        public Customer Customer { get; set; }
        //public object Customers { get; internal set; }

        #endregion

    }
}
