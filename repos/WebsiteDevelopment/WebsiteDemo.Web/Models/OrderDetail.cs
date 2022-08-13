using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteDemo.Web.Models
{
    [Table(name: "OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Order Detail ID")]
        public int OrderDetailID { get; set; }

        [Required]
        [Display(Name ="Your Table Number")]
        public int TableNumber { get; set; }

        [Required]
        [Display(Name ="Enter your Quantity")]
        public int Quantity { get; set; }


        #region Navigation Properties to the Food Model

        [Required]
        virtual public int FoodId { get; set; }

        [ForeignKey(nameof(OrderDetail.FoodId))]
        public Food Food { get; set; }

        #endregion

        #region Navigation Properties to the Order Model

        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderDetail.OrderId))]
        public Order Order { get; set; }

        #endregion

       
    }
}
