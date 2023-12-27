using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTask.BLL.Interfaces
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public ICitiesRepository   CitiesRepository { get; set; }

        public Task<int> CompleteAsync();


    }
}
