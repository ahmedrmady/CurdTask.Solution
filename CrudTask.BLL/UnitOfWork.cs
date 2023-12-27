using CrudTask.BLL.Interfaces;
using CrudTask.BLL.Reopsitory;
using CrudTask.DAL.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTask.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
    
        private readonly AppDbContext _context;

        public IEmployeeRepository EmployeeRepository { get ; set ; }
        public ICitiesRepository CitiesRepository { get; set ; }

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
            EmployeeRepository = new EmployeeRepository(context);
            CitiesRepository = new CitiesRepository (context);
        }

        public async Task<int> CompleteAsync()
        => await _context.SaveChangesAsync();

        public async ValueTask DisposeAsync()
        => await _context.DisposeAsync();
    }
}
