using KnowledgeHubPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHubPortal.Data
{
    public class KHPortalDbContext : DbContext
    {




        // Configure DB

        public KHPortalDbContext(DbContextOptions<KHPortalDbContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=BrodridgeKHPortalDB2025;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed the DB
            List<Catagory> catagories = new List<Catagory>()
            {
                new Catagory{Id=111, Name = "Sports", Description="Sports related articles" },
                new Catagory{Id=222, Name = "Education", Description="Education related articles" },
                new Catagory{Id=333, Name = ".Net", Description=".Net related articles" },
                new Catagory{Id=444, Name = "MVC", Description="MVC related articles" },
                new Catagory{Id=555, Name = "AI", Description="AI related articles" }
            };
            modelBuilder.Entity<Catagory>().HasData(catagories);
        }

        // Map Tables
        public DbSet<Catagory> Catagories { get; set; }
    }
}
