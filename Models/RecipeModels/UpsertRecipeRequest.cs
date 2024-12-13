using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RecipeModels
{
    public class UpsertRecipeRequest
    {
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
        public ICollection<int>? TagIds { get; set; }
        public ICollection<int>? IngredientIds { get; set; }
    }
}
