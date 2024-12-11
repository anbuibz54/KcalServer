using Models.UserModels.Enums;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public  class User
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public float? Height { get; set; }

    public float? Weight { get; set; }

    public Gender? Gender { get; set; }
    public int? Age { get; set; }

    public long? ActivityRateId { get; set; }

    public string? Carts { get; set; }

    public virtual ActivityRate? ActivityRate { get; set; }

    public virtual ICollection<FavoriteFood> FavoriteFoods { get; set; } = new List<FavoriteFood>();

    public virtual ICollection<MealSchedule> MealSchedules { get; set; } = new List<MealSchedule>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();

    public virtual ICollection<UsersRecipe> UsersRecipes { get; set; } = new List<UsersRecipe>();
    public void Update(User u)
    {
        foreach (var item in u.GetType().GetProperties())
        {
            if (item.Name == "Id") continue;
            if (item.PropertyType == typeof(int) && item.GetValue(u).ToString() == "0") continue;
            if (item.PropertyType == typeof(double) && item.GetValue(u).ToString() == "0") continue;
            if (item.GetValue(u) == null) continue;
            this.GetType().GetProperty(item.Name).SetValue(this, item.GetValue(u));
        }
        u.CreatedAt = DateTime.UtcNow;
    }
}
