using CrudTask.DAL.Data.Entites;
using System.ComponentModel.DataAnnotations;

namespace CurdTask.PL.ViewModels
{
    public class EmployeeToReturnViewModel:EmployeeBaseViewModel
    {

        [Display(Name ="City")]
        public virtual string CityName { get; set; }

        [Display(Name = "Sub City")]
        public virtual string SubCityName { get; set; }
       
        [Display(Name = "Village")]
        public virtual string VillageName { get; set; }
    }
}
