using System;
using System.ComponentModel.DataAnnotations;

namespace LMS.Web.Areas.Demos.ViewModels
{
    public class EmployeeViewModel
    {
        [Display]
        [Required(ErrorMessage = "{0} cannot be empty")]
        public int Id { get; set; }

        [Display]
        [Required]
        [MaxLength(80)]
        [MinLength(2)]
        public string EmployeeName {  get; set; }

        [Required]
        public DateTime DateOfBirth {  get; set; }

        [Range (minimum:0, maximum: 200000,ErrorMessage ="{0} has to be between {1} and {2}")]
        public decimal Salary {  get; set; }
     
        public bool IsEnabled { get; set; }

    }
}
