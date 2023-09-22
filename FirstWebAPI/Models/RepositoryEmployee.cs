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
        public Employee UpdateCustomer(int id, Employee updatedEmployeeData)
        {
            Employee employee = _context.Employees.Find(id);
            if (employee == null)
            {
                throw new ArgumentException("Customer not found.");
            }
            _context.Employees.Update(employee);

            // Save changes to the database
            _context.SaveChanges();

            return employee;

        }
        public Employee DeleteEmployee(int id)
        {
            Employee employee = _context.Employees.Find(id);
            if (employee == null)
            {
                throw new ArgumentException("Customer not found.");
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return employee;
        }
    }
}
