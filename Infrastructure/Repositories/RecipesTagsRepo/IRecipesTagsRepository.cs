using Domain.Common;
using Domain.RecipesTags;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.RecipesTagsRepo
{
    public interface IRecipesTagsRepository: IBaseRepository<RecipesTags>
    {
        public Task<ICollection<RecipesTags>> GetAllByRecipeId(long recipeId);
        public Task AddRange(List<RecipesTags> recipesTags);
        public Task RemoveRange(long recipeId);
    }
}
