using Domain.Food;
using Infrastructure.Seedwork;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Food: BaseEntity<Food>
{
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
    public void Update(Food e)
    {
        foreach (var item in e.GetType().GetProperties())
        {
            if (item.Name == "Id") continue;
            if (item.PropertyType == typeof(int) && item.GetValue(e).ToString() == "0") continue;
            if (item.PropertyType == typeof(double) && item.GetValue(e).ToString() == "0") continue;
            if (item.GetValue(e) == null) continue;
            this.GetType().GetProperty(item.Name).SetValue(this, item.GetValue(e));
        }
    }
}
