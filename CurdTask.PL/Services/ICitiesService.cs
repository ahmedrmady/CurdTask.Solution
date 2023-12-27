using CrudTask.DAL.Data.Entites;

namespace CurdTask.PL.Services
{
    public interface ICitiesService
    {
        public Task<IEnumerable<City>> GetCities();
        public Task<IEnumerable<SubCity>> GetSubCities(int cityId);
        public Task<IEnumerable<Village>> GetVillages(int subCityId);
    }
}
