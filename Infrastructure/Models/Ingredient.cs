using Infrastructure.Seedwork;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Ingredient: BaseEntity<Ingredient>
{

    public DateTime CreatedAt { get; set; }

    public long? RecipeId { get; set; }

    public double? Weight { get; set; }

    public long? FoodId { get; set; }

    public virtual Food? Food { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
