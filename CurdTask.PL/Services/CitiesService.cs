using CrudTask.BLL.Interfaces;
using CrudTask.DAL.Data.Entites;

namespace CurdTask.PL.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CitiesService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<City>> GetCities()
        => await _unitOfWork.CitiesRepository.GetCities();

        public async Task<IEnumerable<SubCity>> GetSubCities(int subCityId)
         => await _unitOfWork.CitiesRepository.GetSubCities(subCityId);

        public async Task<IEnumerable<Village>> GetVillages(int subCityId)
         => await _unitOfWork.CitiesRepository.GetVillages(subCityId);
    }
}
