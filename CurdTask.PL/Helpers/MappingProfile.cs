using AutoMapper;
using CrudTask.DAL.Data.Entites;
using CurdTask.PL.ViewModels;

namespace CurdTask.PL.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeToReturnViewModel>()
                .ForMember(D => D.CityName, O => O.MapFrom(S => S.City.CityName))
                .ForMember(D => D.SubCityName, O => O.MapFrom(S => S.SubCity.SubCityName))
                .ForMember(D => D.VillageName, O => O.MapFrom(S => S.Village.VillageName));

            CreateMap< EmployeeViewModel, Employee>().ReverseMap();

            CreateMap<City, CityDto>();

            CreateMap< SubCity, SubCityDto>();
                
            CreateMap< Village, VillageDto>();

        }
    }

}
