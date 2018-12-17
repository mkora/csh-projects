using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await context.ProductItems.ToListAsync();
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var item = await context.ProductItems.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;

        }

        // POST api/products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product item)
        {
            context.ProductItems.Add(item);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetProductItem", new { id = item.Id }, item);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, Product item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            context.Entry(item).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(long id)
        {
            var item = await context.ProductItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            context.ProductItems.Remove(item);
            await context.SaveChangesAsync();

            return item;
        }
    }
}
