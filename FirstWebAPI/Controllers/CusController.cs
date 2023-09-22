using Microsoft.AspNetCore.Mvc;
using FirstWebAPI.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CusController : ControllerBase
    {
        private RepositoryCustomer _repositoryCustomer;
      
        
        // GET: api/<CusController>
        [HttpGet]
        //public IEnumerable<list> Get()
        //{
        //    //return new string[] { "value1", "value2" };
        //    List<Cus>list = new List<Cus>();
        //    list.Add(new Cus() { Name = "Ram", Email = "haros.02@gmail.com" });
        //    return list;
        //}

        // GET api/<CusController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CusController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CusController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
