using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductsCatalogService.Entities;

namespace ProductsCatalogService.Data
{
    public class ProductsDbContext : IdentityDbContext<IdentityUser> //DbContext
    {
        // configure database


        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {

        }

        // map entities with tables

        public DbSet<Product> Products { get; set; }
    }



    class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
