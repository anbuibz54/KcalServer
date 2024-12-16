using Infrastructure.Seedwork;
using Models.RecipeModels;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Recipe: BaseEntity<Recipe>
{

    public DateTime CreatedAt { get; set; }

    public long? UserId { get; set; }

    public string? Title { get; set; }

    public string? TutorialUrl { get; set; }
    public string? Description { get; set; }
    public string? Thumbnail { get; set; }
    public double? DurationInMinutes { get; set; }
    public bool? IsPublic { get; set; }
    public string? Instruction { get; set; }
    public RecipeLevel? Level { get; set; }

    public float? ReviewScore { get; set; }

    public double? Price { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual ICollection<ScheduleItem> ScheduleItems { get; set; } = new List<ScheduleItem>();

    public virtual User? User { get; set; }

    public virtual ICollection<FavoriteRecipes> FavoriteRecipes { get; set; } = new List<FavoriteRecipes>();
    public virtual ICollection<RecipesTags> RecipesTags { get; set; } = new List<RecipesTags>();
}
