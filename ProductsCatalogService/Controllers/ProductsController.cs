using Microsoft.AspNet.OData;
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
    }
}
