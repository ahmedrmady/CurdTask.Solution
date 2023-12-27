using CrudTask.BLL.Interfaces;
using CrudTask.DAL.Data.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTask.BLL.Reopsitory
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly AppDbContext _context;

        public CitiesRepository(AppDbContext context)
        {
            this._context = context;
        }

        



        #region MyRegion
        public async Task<IEnumerable<City>> GetCities()
     => await _context.Cities
                     .AsNoTracking()
                     .ToListAsync();

        public async Task<IEnumerable<SubCity>> GetSubCities(int cityId)
           => await _context.SubCities.Where(S => S.CityId == cityId)
                       .AsNoTracking()
                       .ToListAsync();

        public async Task<IEnumerable<Village>> GetVillages(int subCityId)
          => await _context.Villages.Where(V => V.SubCityId == subCityId)
                       .AsNoTracking()
                       .ToListAsync();
        #endregion
    }
}
