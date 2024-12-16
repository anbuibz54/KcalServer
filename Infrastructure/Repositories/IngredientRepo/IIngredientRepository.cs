using Domain.Common;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.IngredientRepo
{
    public interface IIngredientRepository: IBaseRepository<Ingredient>
    {
        public Task<ICollection<Ingredient>> GetAllByRecipeId(long recipeId);
        public Task AddRange(List<Ingredient> ingredients);
        public Task RemoveRangeByRecipeId(long recipeId);
    }
}
