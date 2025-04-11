using EFDemoApp.DataLayer;
using EFDemoApp.Entities;

namespace EFDemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Product Catalog Management Application - CRUD

            // Step1: Download and Install from nuget.org - use package manager - CLI and GUI

            // Step2: Development Approach
            // Code First Approach - Selected
            // DB First Approach

            // Step 3: Create Entity Classess manually - Code First

            // Step 4: Configure the DB and Map Class with Tables manully - Code First

            // Step 5: Migrate the database and tables - create db and tables by generating script

            // Step 6: Perform CRUD operations on database

            // GEt all products then display

            // Delete a productid 1 record

            // Edit a record

            ProductsDbContext dbContext = new ProductsDbContext();
            var productToEdit = dbContext.Products.Find(2);
            productToEdit.Price += 1000;
            dbContext.SaveChanges();
        }

        private static void Delete()
        {
            ProductsDbContext dbContext = new ProductsDbContext();
            //var productToDel = (from product in dbContext.Products
            //                   where product.ProductID == 1
            //                   select product).FirstOrDefault();

            var productToDel = dbContext.Products.Find(1);

            dbContext.Products.Remove(productToDel);
            dbContext.SaveChanges();
        }

        private static void Select()
        {
            ProductsDbContext dbContext = new ProductsDbContext();

            var products = from p in dbContext.Products
                           select p;

            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }
        }

        private static void Save()
        {
            // Store a single product into into db
            Product product2 = new Product { Name = "IPhone 16", Price = 80000 };
            Product product3 = new Product { Name = "Galaxy S24", Price = 70000 };
            Product product4 = new Product { Name = "IPhone 17", Price = 90000 };
            Product product5 = new Product { Name = "Dell XPS 25", Price = 180000 };

            ProductsDbContext db = new ProductsDbContext();

            db.Products.Add(product2);
            db.Products.Add(product3);
            db.Products.Add(product4);
            db.Products.Add(product5);

            db.SaveChanges();
            Console.WriteLine("Saved");
        }
    }
}
