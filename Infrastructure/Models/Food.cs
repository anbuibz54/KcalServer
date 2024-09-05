using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Food
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public double? Calories { get; set; }

    public double? Fat { get; set; }

    public double? Protein { get; set; }

    public double? Carbohydrate { get; set; }

    public double? ServingWeight { get; set; }

    public string? ServingUnit { get; set; }

    public virtual ICollection<FavoriteFood> FavoriteFoods { get; set; } = new List<FavoriteFood>();

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
