using FirstWebAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace FirstWebAPI.Models
{
    public class RepositoryCustomer
    {
        private NorthwindContext _context;
        public RepositoryCustomer(NorthwindContext context)
        {
            _context = context;
        }
        public List<Customer> GetAllCustomer()
        {
            return _context.Customers.ToList();
        }
        public Customer GetCustomerByid(string id)
        {
            Customer customer= _context.Customers.Find(id);
           
            return customer;
        }
        public Customer UpdateCustomer(string id,Customer updatedCustomerData)
        {
            Customer customer = _context.Customers.Find(id);
            if(customer == null)
            {
                throw new ArgumentException("Customer not found.");
            }
            _context.Customers.Update(customer);

            // Save changes to the database
            _context.SaveChanges();

            return customer;
            
        }
        public Customer DeleteCustomer(string id)
        {
            Customer customer=_context.Customers.Find(id);
            if(customer == null)
            {
                throw new ArgumentException("Customer not found.");
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return customer;
        }
    }
}
