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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            this._context = context;
        }

        
        #region MyRegion
        public void AddEmployee(Employee employee)
        => _context.Add(employee);

        public void DeleteEmployee(Employee employee)
        {
            employee.IsDeleted = true;
            UpdateEmployee(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        => await _context.Employees.AsNoTracking()
                                   .Where(E => E.IsDeleted == false)
                                   .Include(e => e.City)
                                   .Include(e => e.SubCity)
                                   .Include(e => e.Village)
                                   .ToListAsync();

        public async Task<Employee?> GetEmployeeByIdAsync(string id)
        => await _context.Employees.Where(e => e.EmployeeId == id && e.IsDeleted == false)
                                    .Include(e => e.City)
                                    .Include(e => e.SubCity)
                                    .Include(e => e.Village)
                                    .SingleOrDefaultAsync();

        public void UpdateEmployee(Employee employee)
        => _context.Employees.Update(employee);
        #endregion
    }
}
