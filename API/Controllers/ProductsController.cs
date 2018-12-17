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

        public ProductsController(ProductContext context)
        {
            this.context = context;
        }


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

            return item;
        }

        // PUT api/products/1
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(long id, Product item)
        {
            var dbItem = await context.ProductItems.FindAsync(id);

            context.Entry(dbItem).State = EntityState.Modified;
            if (item.Name != null)
                dbItem.Name = item.Name;
            if (item.Price > 0)
                dbItem.Price = item.Price;
            if (item.Description != null)
                dbItem.Description = item.Description;
            await context.SaveChangesAsync();

            return dbItem;
        }

        // DELETE api/products/1
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
