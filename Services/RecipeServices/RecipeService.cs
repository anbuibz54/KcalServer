using AutoMapper;
using Domain.Recipe;
using Infrastructure.Repositories.RecipeRepo;
using Models.Common;
using Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RecipeServices
{
    public interface IRecipeService
    {
        Task<PaginationResponse<RecipeDomain>> GetAll(ListRecipesRequest request);
    }
    public class RecipeService(IRecipeRepository recipeRepository, IMapper mapper) : IRecipeService
    {
        public async Task<PaginationResponse<RecipeDomain>> GetAll(ListRecipesRequest request)
        {
            var entities = await recipeRepository.GetAll(request.Pagination, request.Sort, request.Filter);
            var result = mapper.Map<PaginationResponse<RecipeDomain>>(entities);
            return result;
        }
    }
}
