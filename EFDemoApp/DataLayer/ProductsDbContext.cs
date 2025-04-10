﻿using EFDemoApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFDemoApp.DataLayer
{
    public class ProductsDbContext : DbContext
    {

        // Configure Database


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=BrodridgeProductsDB2025;Integrated Security=True");
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        // Map Entity Classes with Tables

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
