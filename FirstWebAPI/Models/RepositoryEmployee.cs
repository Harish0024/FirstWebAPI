using Microsoft.EntityFrameworkCore;

namespace FirstWebAPI.Models
{
    public class RepositoryEmp
    {
        private NorthwindContext _context;
        public RepositoryEmp(NorthwindContext context)
        {
            _context = context;
        }
        public List<Employee> GetAllEmp()
        {

            return _context.Employees.ToList();

        }
        public Employee GetEmployeeId(int id)
        {
            Employee employee = _context.Employees.Find(id);
            return employee;
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        public Employee UpdateEmployee( Employee updatedEmployeeData)
        { 
        
            _context.Employees.Update(updatedEmployeeData);

            // Save changes to the database
            _context.SaveChanges();

            return updatedEmployeeData;

        }
        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            
        }
    }
}
