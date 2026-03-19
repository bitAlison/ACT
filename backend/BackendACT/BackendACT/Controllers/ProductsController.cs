using backend.Data;
using BackendACT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendACT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private static bool DbLoaded = false;

        /// <summary>
        /// Initializes a new instance of the ProductsController class using the specified database context.
        /// </summary>
        /// <remarks>This constructor is typically used by dependency injection to provide the required
        /// database context for the controller's operations.</remarks>
        /// <param name="context">The database context to be used for accessing product data. Cannot be null.</param>
        public ProductsController(AppDbContext context)
        {
            _context = context;
            if (!DbLoaded)
            {
                DbLoaded = true;
                PopulateProductsDB();
            }
        }

        /// <summary>
        /// Retrieves all products from the data store.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see
        /// cref="ActionResult{T}">ActionResult</see> with a collection of <see cref="Products"/> objects representing
        /// all products. Returns an empty collection if no products are found.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// Retrieves the product with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to retrieve.</param>
        /// <returns>An ActionResult containing the product with the specified identifier if found; otherwise, a NotFound result.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> Get(int id)
        {
            var Products = await _context.Products.FindAsync(id);

            if (Products == null)
                return NotFound();

            return Products;
        }

        /// <summary>
        /// Creates a new product and adds it to the data store.
        /// </summary>
        /// <remarks>If the product is successfully created, the response includes a 201 Created status
        /// code and the URI of the new product. The request body must contain a valid product entity.</remarks>
        /// <param name="Products">The product entity to add. Must not be null.</param>
        /// <returns>An ActionResult containing the created product and a location header with the URI of the newly created
        /// resource.</returns>
        [HttpPost]
        public async Task<ActionResult<Products>> Post(Products Products)
        {
            _context.Products.Add(Products);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = Products.Id }, Products);
        }

        /// <summary>
        /// Updates the details of an existing product with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to update. Must match the identifier of the provided product entity.</param>
        /// <param name="Products">The product entity containing the updated values. The entity's Id property must match the specified
        /// identifier.</param>
        /// <returns>An IActionResult indicating the result of the update operation. Returns NoContent if the update is
        /// successful; otherwise, returns BadRequest if the identifiers do not match.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Products Products)
        {
            if (id != Products.Id)
                return BadRequest();

            _context.Entry(Products).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Deletes the product with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete.</param>
        /// <returns>An <see cref="IActionResult"/> that represents the result of the delete operation. Returns <see
        /// cref="NotFoundResult"/> if the product does not exist; otherwise, returns <see cref="NoContentResult"/> on
        /// successful deletion.</returns>
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

        /// <summary>
        /// Populates the products database with a predefined set of product entries.
        /// </summary>
        /// <remarks>This method asynchronously adds a fixed list of sample products to the database
        /// context and saves the changes. Intended for initial data seeding or testing scenarios. Calling this method
        /// multiple times may result in duplicate entries if not managed appropriately.</remarks>
        private async void PopulateProductsDB()
        {
            var productList = new Products[]
            {
                new() { Id = 1, Name = "Burger", Price = 19.9, Image = new Uri("https://i.postimg.cc/N0Wypw56/combo0001.png") },
                new() { Id = 2, Name = "Frango", Price = 17.5, Image = new Uri("https://i.postimg.cc/rpvdQLK9/combo0002.png") },
                new() { Id = 3, Name = "Sanduíche", Price = 21.5, Image = new Uri("https://i.postimg.cc/25Pq2fVd/combo0003.png") },
                new() { Id = 4, Name = "Nuggets", Price = 18.9, Image = new Uri("https://i.postimg.cc/jjGWZrLZ/combo0005.png") },
                new() { Id = 5, Name = "Tortilha", Price = 17.9, Image = new Uri("https://i.postimg.cc/d0z74KL5/combo0006.png") },
                new() { Id = 6, Name = "Soda", Price = 29.1, Image = new Uri("https://i.postimg.cc/1t3q8KnM/prod0019.png") }
            };

            _ = _context.Products.AddRangeAsync(productList);
            await _context.SaveChangesAsync();
        }
    }
}
