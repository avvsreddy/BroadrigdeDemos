using System;
using System.Collections.Generic;

namespace EFDbFirstDemo.Models;

public partial class Customer
{
    public int PersonId { get; set; }

    public int Discount { get; set; }

    public string? EmailId { get; set; }

    public string? Mobile { get; set; }

    public string Name { get; set; } = null!;
}
