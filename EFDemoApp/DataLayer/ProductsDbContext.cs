using EFDemoApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFDemoApp.DataLayer
{
    public class ProductsDbContext : DbContext
    {

        // Configure Database


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=BrodridgeProductsDB2025;Integrated Security=True;MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Person>().UseTphMappingStrategy();

            //modelBuilder.Entity<Person>().UseTptMappingStrategy();

            modelBuilder.Entity<Person>().UseTpcMappingStrategy();

            modelBuilder.Entity<Category>().HasData(

                new Category { CategoryID = 111, Name = "Category 1" },
                new Category { CategoryID = 222, Name = "Category 2" },
                new Category { CategoryID = 333, Name = "Category 3" },
                new Category { CategoryID = 444, Name = "Category 4" },
                new Category { CategoryID = 555, Name = "Category 5" }


            );
        }

        // Map Entity Classes with Tables

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<Customer> Customers { get; set; }

    }
}
