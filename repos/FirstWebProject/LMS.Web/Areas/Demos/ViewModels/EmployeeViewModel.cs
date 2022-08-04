using System;
using System.ComponentModel.DataAnnotations;

namespace LMS.Web.Areas.Demos.ViewModels
{
    public class EmployeeViewModel
    {
        [Display]
        [Required(ErrorMessage = "{0} cannot be empty")]
        public int Id { get; set; }

        [Display(Name = "Name Of The Employee")]
        [Required(ErrorMessage = "{0}Cannot be Empty")]
        [MaxLength(80, ErrorMessage = "{0} can contain maximum of {1} character")]
        [MinLength(2, ErrorMessage = "{0} should contain a minimum of {1} character")]
        public string EmployeeName {  get; set; }

        [Display(Name ="Date Of Birth")]
        [Required]
        public DateTime DateOfBirth {  get; set; }

        [Range (minimum:0, maximum: 200000,ErrorMessage ="{0} has to be between {1} and {2}")]
        public decimal Salary {  get; set; }

        [Display(Name ="Is Employee allowed to login")]
        public bool IsEnabled { get; set; }

    }
}
