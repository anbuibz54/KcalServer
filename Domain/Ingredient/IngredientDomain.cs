using Domain.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ingredient
{
    public class IngredientDomain
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public long? RecipeId { get; set; }

        public double? Weight { get; set; }

        public long? FoodId { get; set; }

        public FoodDomain? Food { get; set; }
    }
}
