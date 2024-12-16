using Infrastructure.Seedwork;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Product: BaseEntity<Product>
{

    public string? Name { get; set; }

    public string? Description { get; set; }

    public List<string>? Images { get; set; }

    public long? ShopId { get; set; }

    public double? Price { get; set; }

    public virtual Shop? Shop { get; set; }
}
