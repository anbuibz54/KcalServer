using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Shop
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Name { get; set; }

    public long? UserId { get; set; }

    public string? Description { get; set; }

    public string? Avatar { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual User? User { get; set; }
}
