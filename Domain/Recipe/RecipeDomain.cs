using Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Recipe
{
    public class RecipeDomain
    {
        public long Id { get; set; }

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
    }
}
