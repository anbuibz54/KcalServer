using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.IngredientRepo
{
    internal class IngredientRepository: BaseRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(CoreContext context) : base(context) { }

        public async Task AddRange(List<Ingredient> ingredients)
        {
            await _DbSet.AddRangeAsync(ingredients);
            await _Context.SaveChangesAsync();
        }

        public async Task<ICollection<Ingredient>> GetAllByRecipeId(long recipeId)
        {
            var entities = await _DbSet.Where(e => e.RecipeId == recipeId).ToListAsync();
            return entities;
        }

        public async Task RemoveRangeByRecipeId(long recipeId)
        {
            await _DbSet.Where(e => e.RecipeId == recipeId).ExecuteDeleteAsync();
        }
    }
}
