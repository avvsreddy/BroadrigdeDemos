namespace EFDbFirstDemo.Models;

public partial class Product
{
    public int ProductId { get; set; }

    //[Required]
    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public string Brand { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Supplier> SuppliersPeople { get; set; } = new List<Supplier>();
}
