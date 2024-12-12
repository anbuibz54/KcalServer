using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.FavoriteRecipes
{
    public class FavoriteRecipesDomain
    {
        public long Id { get; set; }

        public long? RecipeId { get; set; }

        public long? UserId { get; set; }
    }
}
