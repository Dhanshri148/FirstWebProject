using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healthifyme.Web.Models
{
    [Table(name: "Payments")]
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Payment Id")]
        public int PaymentId { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Display(Name = "Type of Payment")]
        public string PaymentType { get; set; }

        [Required]
        [Display(Name = "Enter fees amount")]
        public int? PaymentAmount { get; set; }

        #region Navigation Properties to the Customer Model
        public ICollection<Customer> Customers { get; set; }

        #endregion


    }
}
