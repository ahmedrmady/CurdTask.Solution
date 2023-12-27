using CrudTask.DAL.Data.Entites;

namespace CrudTask.PL.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        public Task<Employee?> GetEmployeeByIdAsync(string id);

        public Task<Employee?> AddEmployeeAsunc(Employee employee);

        public Task<Employee?> UpdateEmployeeAsync(Employee employee);

        public Task<bool> DeleteEmployeeAsync(Employee employee);

    }
}
