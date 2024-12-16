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
        [HttpPost("add")]
        public async Task<ApiResult<RecipeDomain>> Add([FromBody]UpsertRecipeRequest request)
        {
            var result = await recipeService.Add(request);
            return new ApiResult<RecipeDomain>().Succeed(result);
        }
        [HttpPut("{id:long}")]
        public async Task<ApiResult<RecipeDomain>> Update(long id,[FromBody]UpsertRecipeRequest request)
        {
            var result = await recipeService.Update(id,request);
            return new ApiResult<RecipeDomain>().Succeed(result);
        }
    }
}
