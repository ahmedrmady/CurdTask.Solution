using CrudTask.DAL.Data.Entites;
using System.ComponentModel.DataAnnotations;

namespace CurdTask.PL.ViewModels
{
    public class EmployeeViewModel :EmployeeBaseViewModel
    {


        [Required]
        [Display(Name="City")]
        public int CityId { get; set; }
        [Required]
        [Display(Name="SubCity")]
        public int SubCityId { get; set; }
        [Required]
        [Display(Name="Village")]
        public int VillageId { get; set; }

       

    }
}
