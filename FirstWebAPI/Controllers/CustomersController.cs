using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private RepositoryCustomer _repositoryCustomer;
        public CustomersController(RepositoryCustomer repository)
        {
            _repositoryCustomer = repository;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public List<Customer> GetAllCustomer()
        {
            List<Customer> list = _repositoryCustomer.GetAllCustomer();
            return list; 
            //return new string[] { "value1", "value2" };
        }

        // GET api/<CustomersController>/5
      
      

        // POST api/<CustomersController>
        [HttpPost]
        public Customer Detail(string id)
        {
            Customer customer = _repositoryCustomer.GetCustomerByid(id);
            return customer;

        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(string id, Customer updatedCustomerData)
        {
            Customer customer=_repositoryCustomer.UpdateCustomer(id, updatedCustomerData);
           
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Customer customer = _repositoryCustomer.DeleteCustomer(id);
           
        }
    }
}
