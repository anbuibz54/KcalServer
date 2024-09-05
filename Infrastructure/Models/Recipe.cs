using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Recipe
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UserId { get; set; }

    public string? Title { get; set; }

    public string? TutorialUrl { get; set; }

    public float? ReviewScore { get; set; }

    public double? Price { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual ICollection<ScheduleItem> ScheduleItems { get; set; } = new List<ScheduleItem>();

    public virtual User? User { get; set; }

    public virtual ICollection<UsersRecipe> UsersRecipes { get; set; } = new List<UsersRecipe>();
}
