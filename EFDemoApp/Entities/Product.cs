namespace EFDemoApp.Entities
{
    //[Table("tbl_items")]
    public class Product
    {
        //[Key]
        public int ProductID { get; set; }
        //[MaxLength(100)]
        //[Required]
        public string Name { get; set; }
        //[Range(100, 10000)]
        public int Price { get; set; }
        //[NotMapped]
        //public int Profit { get; set; }
        public string Brand { get; set; }

        public Category Category { get; set; }
    }


    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}