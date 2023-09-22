using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private RepositoryEmp _repositoryEmployee;
        public EmployeeController(RepositoryEmp repository)
        {
            _repositoryEmployee = repository;
        }
        [HttpGet("/GetAllEmployees")]
        public IEnumerable<EmpViewModel> GetAllEmp()
        {
            List<Employee> employees = _repositoryEmployee.GetAllEmp();
            var emplist = (
                from emp in employees
                select new EmpViewModel()
                {
                    EmpId = emp.EmployeeId,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    BirthDate = emp.BirthDate,
                    HireDate = emp.HireDate,
                    Title = emp.Title,
                    City = emp.City,
                    ReportsTo = emp.ReportsTo
                }
        ).ToList();
            return emplist;
        }
            
        [HttpGet]
        // GET: EmployeeController
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = _repositoryEmployee.GetAllEmp();
            return employees;
        }
        [HttpPost]
        public Employee EmployeeDetails(int id)
        {
            Employee employees = _repositoryEmployee.GetEmployeeId(id);
            return employees;
        }
        [HttpPut]
        public void Put(int id, Employee updatedEmployeeData)
        {
            Employee employee = _repositoryEmployee.UpdateCustomer(id, updatedEmployeeData);

        }
        [HttpDelete]
        public void Delete(int id)
        {
            Employee employee=_repositoryEmployee.DeleteEmployee(id);
        }
    }
}
