using EFDbFirstDemo.Models;

namespace EFDbFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (BrodridgeProductsDb2025Context db = new BrodridgeProductsDb2025Context())
            {
                Category c = new Category() { Name = "New Category" };

                db.Categories.Add(c);
                db.SaveChanges();
            }
        }
    }
}
