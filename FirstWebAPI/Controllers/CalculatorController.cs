using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        //api/calculator/add?x=10&y=20
        [HttpGet("Calculator/add")]
        public int Add(int x,int y)
        {
            return x + y;
        }
        //api/calculator/Sub?x=20&y=10
        [HttpGet("Calculator/sum")]
        public int Sum(int x, int y)
        {
            return x + y+1000;
        }
        //api/calculator/Mul?x=10&y=20
        [HttpPut]
        public int Mul(int x, int y)
        {
            return x * y;
        }
        //api/calculator/Div?x=20&y=10
        [HttpDelete]
        public int Div(int x, int y)
        {
            return x / y;
        }
    }
}
