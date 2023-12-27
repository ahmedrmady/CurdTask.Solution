using AutoMapper;
using ClosedXML.Excel;
using CrudTask.DAL.Data.Entites;
using CrudTask.PL.Services;
using CurdTask.PL.Helpers;
using CurdTask.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CurdTask.PL.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManger;

        public EmployeesController(IEmployeeService service, IMapper mapper,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManger
            )
        {
            this._service = service;
            this._mapper = mapper;
            this.userManager = userManager;
            this.roleManger = roleManger;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employeeList = await _service.GetAllEmployeesAsync();
            var mappedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeToReturnViewModel>>(employeeList);
            return View(mappedEmployees);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Editor")]
        public async Task<IActionResult> Details(string id, string viewName = "Details")
        {
            var employee = await _service.GetEmployeeByIdAsync(id);
            if (viewName == "EditEmployee")
                return View(viewName, _mapper.Map<Employee, EmployeeViewModel>(employee));

            return View(viewName, _mapper.Map<Employee, EmployeeToReturnViewModel>(employee));

        }

        [HttpGet]
        [Authorize(Roles = "Admin,Entry")]
        public IActionResult CreateNewEmployee()
        {

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Entry")]
        public async Task<IActionResult> CreateNewEmployee(EmployeeViewModel model, string metod = "add")
        {
            if (!ModelState.IsValid) return View(model);

            var employee = _mapper.Map<EmployeeViewModel, Employee>(model);
            try
            {
                if (metod == "add")
                    await _service.AddEmployeeAsunc(employee);
                if (metod == "update")
                    await _service.UpdateEmployeeAsync(employee);
            }
            catch (Exception ex)
            {
                return View("Error");
                throw;
            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> EditEmployee(string id)
        => await Details(id, "EditEmployee");


        [HttpPost]
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> EditEmployee(EmployeeViewModel model)
        {

            if (!ModelState.IsValid) return View(model);

            return await CreateNewEmployee(model, "update");
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> DeleteEmployee([FromQuery] string empId)
        {
            var employee = await _service.GetEmployeeByIdAsync(empId);
            if (employee is not null)
            {

                await _service.DeleteEmployeeAsync(employee);
                return Ok();
            }
            else
                return BadRequest();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<FileResult> ExportEmployeesInExecl()
        {
            var employees = await _service.GetAllEmployeesAsync();

            return GenerateExcel(_mapper.Map<IEnumerable<Employee>,IEnumerable<EmployeeToReturnViewModel>>(employees), "EmployeesReport.xlsx");
        }

        private FileResult GenerateExcel(IEnumerable<EmployeeToReturnViewModel> employees,string fileName)
        {

            var dataTable = ReportGenrator.GenerateExcel(fileName, employees);
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);

                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        fileName);
                }
            }

        }

        public async Task<FileStreamResult> ExportToPdf(string id)
        {
            var employee = await _service.GetEmployeeByIdAsync(id);

            return (ReportGenrator.ExportToPdf(_mapper.Map<Employee,EmployeeToReturnViewModel>(employee)));
        }

       

    }
}
