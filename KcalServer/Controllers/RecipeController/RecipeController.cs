using Domain.Recipe;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;
using Models.RecipeModels;
using Services.RecipeServices;

namespace KcalServer.Controllers.RecipeController
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController(IRecipeService recipeService):ControllerBase
    {
        [HttpPost("all-by-page")]
        public async Task<ApiResult<PaginationResponse<RecipeDomain>>> GetAllByPage(ListRecipesRequest request)
        {
            var result = await recipeService.GetAll(request);
            return new ApiResult<PaginationResponse<RecipeDomain>>().Succeed(result);
        }
    }
}
