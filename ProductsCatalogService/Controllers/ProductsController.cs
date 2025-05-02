using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsCatalogService.Data;
using ProductsCatalogService.Entities;

namespace ProductsCatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // GET.../api/products
    public class ProductsController : ControllerBase
    {
        private readonly ProductsDbContext db;

        public ProductsController(ProductsDbContext db)
        {
            this.db = db;
        }

        // GET .../api/products
        [HttpGet]
        [EnableQuery]
        public IQueryable<Product> GetProducts()
        {
            return db.Products.AsQueryable();
        }

        // GET .../api/products/123

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await db.Products.FindAsync(id);

            if (product == null) // not found
            {
                // return 404 http status code
                return NotFound($"Product with {id} not found");

            }

            // return data with 200 http status code
            return Ok(product);
        }

        // Get all products belongs to some brand
        // GET .../api/products/brand/apple
        [HttpGet("brand/{brand:alpha}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductByBrand(string brand)
        {
            var products = db.Products.Where(p => p.Brand.Contains(brand));
            if (await products.AnyAsync())
            {
                return Ok(products);
            }
            return NotFound($"{brand} brand products not found");
        }

        // get all products belongs to some country
        [HttpGet("country/{country:alpha}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductByCountry(string country)
        {
            var products = db.Products.Where(p => p.Country.Contains(country));
            if (await products.AnyAsync())
            {
                return Ok(products);
            }
            return NotFound($"{country} country products not found");
        }

        // get all products between price range from min price to max price
        // GET .../api/products/price/min/{min}/max/{max}

        [HttpGet("price/min/{min:int}/max/{max:int}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductByPriceRange(int min, int max)
        {
            var products = from p in db.Products
                           where p.Price >= min && p.Price <= max
                           select p;

            if (await products.AnyAsync())
                return Ok(products);
            return NotFound($"No products available between the price range of {min} and {max}");
        }

        // get cheapest product
        [HttpGet("cheapest")]
        public async Task<IActionResult> GetCheapestProduct()
        {
            var product = await db.Products.OrderBy(p => p.Price).FirstOrDefaultAsync();
            return Ok(product);
        }
        // get costliest product
        [HttpGet("costliest")]
        public async Task<IActionResult> GetCostliestProduct()
        {
            var product = await db.Products.OrderByDescending(p => p.Price).FirstOrDefaultAsync();
            return Ok(product);
        }

        // endpoint for posting the product data

        // POST .../api/products
        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invlid input");
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();
            // return status code 201, location/url then saved data
            // 
            return Created($"/api/products/{product.Id}", product);

        }

        // Endpoint for delete product by id

        // DELETE .../api/products/id
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productToDelete = await db.Products.FindAsync(id);
            if (productToDelete == null)
            {
                return NotFound($"Product {id} not found");
            }
            db.Products.Remove(productToDelete);
            await db.SaveChangesAsync();
            return Ok($"Product {productToDelete.Name} deleted successfully");
        }

        // Endpoint for editing product

        // HTTPPUT .../api/products

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }

            db.Products.Update(product);
            await db.SaveChangesAsync();
            return Ok($"Product {product.Id} updated successfully");


        }
    }
}
