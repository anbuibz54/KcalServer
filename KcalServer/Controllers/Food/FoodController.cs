using Domain.Food;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;
using Models.FoodModels;
using Services.FoodServices;

namespace KcalServer.Controllers.Food
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController(IFoodServices foodServices):ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ApiResult<FoodDomain>> GetById(int id)
        {
            var result = await foodServices.GetFood(id);
            return new ApiResult<FoodDomain>().Succeed(result);
        }
        [HttpGet("all")]
        public async Task<ApiResult<ICollection<FoodDomain>>> GetAll()
        {
            var result = await foodServices.GetAll();
            return new ApiResult<ICollection<FoodDomain>>().Succeed(result);
        }
        [HttpGet("all/page")]
        public async Task<ApiResult<PaginationResponse<FoodDomain>>> GetAllByPage([FromBody] ListFoodsRequest request)
        {
            var result = await foodServices.GetAll(request.PaginationParams,request.FoodFilterParams,request.SortParams);
            return new ApiResult<PaginationResponse<FoodDomain>>().Succeed(result);
        }
        [HttpPost("add")]
        public async Task<ApiResult<FoodDomain>> Add([FromBody] FoodDomain food)
        {
            var result = await foodServices.AddFood(food);
            return new ApiResult<FoodDomain>().Succeed(result);
        }
        [HttpPost("analyze")]
        public async Task<ApiResult<FoodDomain>> Analyze([FromBody] AnalyzeFoodRequest request)
        {
            var result = await foodServices.AnalyzeFood(request);
            return new ApiResult<FoodDomain>().Succeed(result);
        }
        [HttpPut("update/{id}")]
        public async Task<ApiResult<FoodDomain>> Update(int id, [FromBody] FoodDomain food)
        {
            var result = await foodServices.UpdateFood(id, food);
            return new ApiResult<FoodDomain>().Succeed(result);
        }
        [HttpDelete("{id}")]
        public async Task<ApiResult<FoodDomain>> Delete(int id)
        {
            var result = await foodServices.DeleteFood(id);
            return new ApiResult<FoodDomain>().Succeed(result);
        }

    }
}
