using CrudTask.DAL.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTask.BLL.Interfaces
{
    public interface ICitiesRepository
    {
       public Task<IEnumerable<City>> GetCities();
       public Task<IEnumerable<SubCity>> GetSubCities( int cityId);
       public Task<IEnumerable<Village>> GetVillages(int subCityId);
    }
}
