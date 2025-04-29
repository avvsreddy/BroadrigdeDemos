using Microsoft.EntityFrameworkCore;
using ProductsCatalogService.Entities;

namespace ProductsCatalogService.Data
{
    public class ProductsDbContext : DbContext
    {
        // configure database


        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {

        }

        // map entities with tables

        public DbSet<Product> Products { get; set; }
    }
}
