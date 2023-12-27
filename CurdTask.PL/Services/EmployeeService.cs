using CrudTask.BLL.Interfaces;
using CrudTask.DAL.Data.Entites;

namespace CrudTask.PL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Employee?> AddEmployeeAsunc(Employee employee)
        {
             _unitOfWork.EmployeeRepository.AddEmployee(employee);
            var result= await  _unitOfWork.CompleteAsync();

            return result>0 ?employee:null;
        }

        public async Task<bool> DeleteEmployeeAsync(Employee employee)
        {
            _unitOfWork.EmployeeRepository.DeleteEmployee(employee);
            var result =  await _unitOfWork.CompleteAsync();
          return  result >0? true:false;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
         => await _unitOfWork.EmployeeRepository.GetAllEmployeesAsync();

        public async Task<Employee?> GetEmployeeByIdAsync(string id)
        => await _unitOfWork.EmployeeRepository.GetEmployeeByIdAsync(id);

        public async Task<Employee?> UpdateEmployeeAsync(Employee employee)
        {
            _unitOfWork.EmployeeRepository.UpdateEmployee(employee);
            var result = await _unitOfWork.CompleteAsync();

          return  result > 0 ? employee : null;
        }
    }
}
