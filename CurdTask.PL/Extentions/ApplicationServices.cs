using CrudTask.BLL;
using CrudTask.BLL.Interfaces;
using CrudTask.BLL.Reopsitory;
using CrudTask.PL.Services;
using CurdTask.PL.Helpers;
using CurdTask.PL.Services;

namespace CrudTask.PL.Extentions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped(typeof(ICitiesRepository),typeof(CitiesRepository));
            services.AddScoped(typeof(ICitiesService),typeof(CitiesService));
            services.AddScoped(typeof(IEmployeeService),typeof(EmployeeService));
            services.AddScoped(typeof(IUnitOfWork),typeof(UnitOfWork));
            services.AddAutoMapper(typeof( MappingProfile));
            return services;
        }

    }
}
