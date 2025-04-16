using System;
using System.Collections.Generic;

namespace EFDbFirstDemo.Models;

public partial class Supplier
{
    public int PersonId { get; set; }

    public string? Gst { get; set; }

    public int? Rating { get; set; }

    public string? EmailId { get; set; }

    public string? Mobile { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> ProductsProducts { get; set; } = new List<Product>();
}
