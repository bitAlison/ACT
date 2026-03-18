using backend.Data;
using BackendACT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> Get(int id)
        {
            var Products = await _context.Products.FindAsync(id);

            if (Products == null)
                return NotFound();

            return Products;
        }

        [HttpPost]
        public async Task<ActionResult<Products>> Post(Products Products)
        {
            _context.Products.Add(Products);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = Products.Id }, Products);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Products Products)
        {
            if (id != Products.Id)
                return BadRequest();

            _context.Entry(Products).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Products = await _context.Products.FindAsync(id);

            if (Products == null)
                return NotFound();

            _context.Products.Remove(Products);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
