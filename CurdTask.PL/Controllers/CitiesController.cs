using AutoMapper;
using CrudTask.DAL.Data.Entites;
using CurdTask.PL.Services;
using CurdTask.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurdTask.PL.Controllers
{
    [Authorize]
    public class CitiesController : Controller
    {
        private readonly ICitiesService _citiesService;
        private readonly IMapper _mapper;

        public CitiesController(ICitiesService citiesService,IMapper mapper)
        {
            this._citiesService = citiesService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _citiesService.GetCities();
            return Ok(_mapper.Map<IEnumerable<City>, IEnumerable<CityDto>>(cities));
        }
        [HttpGet]
        public async Task<IActionResult> GetSubCities( int cityId )
        {
            var subCities = await _citiesService.GetSubCities(cityId);
            return Ok(_mapper.Map<IEnumerable<SubCity>, IEnumerable<SubCityDto>>(subCities));
        }

        [HttpGet]
        public async Task<IActionResult> GetVillages(int subCityId)
        {
            var villages = await _citiesService.GetVillages(subCityId);
            return Ok(_mapper.Map<IEnumerable<Village>, IEnumerable<VillageDto>>(villages));
        }
    }
}
