namespace CollectionDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? a = null;

            // LIST

            //List<int> numbers = new List<int>();
            //numbers.Add(1);
            //numbers.Add(51);
            //numbers.Add(14);
            //numbers.Add(11);
            //numbers.Add(19);
            //numbers.TrimExcess();
            //Console.WriteLine($"Count {numbers.Count}");
            //Console.WriteLine($"Capacity {numbers.Capacity}");

            //numbers.Sort();
            //numbers.Reverse();

            //foreach (int i in numbers)
            //{
            //    Console.WriteLine(i);
            //}
            //// add
            //numbers.Add(1);
            //// read
            //int x = numbers[0];

            List<Product> products = new List<Product>();

            Product p1 = new Product { Id = 111, Name = "IPhone", Price = 79000 };
            products.Add(p1);
            Product p2 = new Product { Id = 222, Name = "Galaxy S24", Price = 99000 };
            products.Add(p2);
            Product p3 = new Product { Id = 333, Name = "IPhone 16", Price = 89000 };
            products.Add(p3);

            // sort and display display all

            products.Sort(new ProductPriceComparer());

            var sortedProducts = from p in products orderby p.Price descending select p;

            foreach (Product p in products)
            {
                Console.WriteLine(p.Id + "\t" + p.Name + "\t" + p.Price);
            }

        }
    }

    class Product //: IComparable<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        //public int CompareTo(Product? other)
        //{
        //    // compare current product with next product on price then return 1 if bigger, -1 if smaller, 0 if same
        //    if (this.Price > other.Price) return 1;
        //    if (this.Price < other.Price) return -1;
        //    //if(this.Price == other.Price) return 0;
        //    return 0;
        //}
    }

    class ProductPriceComparer : IComparer<Product>
    {
        public int Compare(Product? x, Product? y)
        {
            return (x.Price > y.Price) ? 1 : -1;

        }
    }
}
