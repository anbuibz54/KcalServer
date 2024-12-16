using Domain.FavoriteFood;
using Domain.Ingredient;
using Domain.RecipesTags;
using Domain.Tag;
using Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = Domain.UserDomain.User;
namespace Domain.Recipe
{
    public class RecipeDomain
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }  = DateTime.Now;

        public long? UserId { get; set; }

        public string? Title { get; set; }

        public string? TutorialUrl { get; set; }
        public string? Description { get; set; }
        public string? Thumbnail { get; set; }
        public double? DurationInMinutes { get; set; }
        public bool? IsPublic { get; set; }
        public RecipeInstructionModel? Instruction { get; set; }
        public RecipeLevel? Level { get; set; }

        public float? ReviewScore { get; set; }

        public double? Price { get; set; }
        public ICollection<IngredientDomain>? Ingredients { get; set; } = new List<IngredientDomain>();
        public User? User { get; set; }
        public List<TagDomain>? Tags { get; set; }
    }
}
