using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public virtual Category Category { get; set; }
        public virtual List<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }


    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }

    public class Supplier
    {
        public int SupplierID { get; set; }
        [Required]
        public string Name { get; set; }
        public string? EmailId { get; set; }

        public string? Mobile { get; set; }

        public string? GST { get; set; }

        public int? Rating { get; set; }




        public virtual List<Product> Products { get; set; } = new List<Product>();

        public Address Address { get; set; }
    }

    [ComplexType]
    public class Address
    {
        public string Area { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
    }
}