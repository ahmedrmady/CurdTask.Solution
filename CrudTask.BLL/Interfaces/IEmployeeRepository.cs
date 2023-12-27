using CrudTask.DAL.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTask.BLL.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        public Task<Employee?> GetEmployeeByIdAsync(string id);

        public void AddEmployee(Employee employee);

        public void UpdateEmployee(Employee employee);

        public void DeleteEmployee(Employee employee);




    }
}
