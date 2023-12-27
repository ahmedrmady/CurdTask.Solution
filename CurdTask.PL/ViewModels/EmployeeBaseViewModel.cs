using System.ComponentModel.DataAnnotations;

namespace CurdTask.PL.ViewModels
{
    public class EmployeeBaseViewModel
    {
        [Required]
        [Display(Name = "ID")]
        [MinLength(14),MaxLength(14)]
        public string EmployeeId { get; set; }

        [Required]
        [Display(Name="Employee Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Salary")]

        [Range(5000, 50000)]
        public decimal Salary { get; set; }

       
        
    }
}
