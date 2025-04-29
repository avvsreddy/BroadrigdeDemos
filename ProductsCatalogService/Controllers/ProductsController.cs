using Microsoft.AspNetCore.Mvc;
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
        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

    }
}
