using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext context;

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetProducts()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<string> GetProduct(int id)
        {
            return "value";
        }

        // POST api/products
        [HttpPost]
        public void PostProduct([FromBody] string value)
        {
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void PutProduct(int id, [FromBody] string value)
        {
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
        }
    }
}
