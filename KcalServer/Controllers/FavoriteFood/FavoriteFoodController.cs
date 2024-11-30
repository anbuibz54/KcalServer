using Domain.FavoriteFood;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;
using Models.FavoriteFoodModels;
using Services.FavoriteFoodServices;

namespace KcalServer.Controllers.FavoriteFood
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteFoodController(IFavoriteFoodService favoriteFoodService): ControllerBase
    {
        [HttpGet("all")]
        public async Task<ApiResult<PaginationResponse<FavoriteFoodDomain>>> GetAll([FromBody] ListFavoriteFoodsRequest request) 
        {
            var result = await favoriteFoodService.GetAll(request.paginationParams,request.sortParams,request.filterParams);
            return new ApiResult<PaginationResponse<FavoriteFoodDomain>>().Succeed(result);
        }
        [HttpGet("{id:int}")]
        public async Task<ApiResult<FavoriteFoodDomain>> GetById(int id)
        {
            var result = await favoriteFoodService.GetFavoriteFoodById(id);
            return new ApiResult<FavoriteFoodDomain>().Succeed(result);
        }
        [HttpPost("add")]
        public async Task<ApiResult<FavoriteFoodDomain>> Add([FromBody] UpsertFavoriteFoodParams body)
        {
            var result = await favoriteFoodService.Add(body);
            return new ApiResult<FavoriteFoodDomain>().Succeed(result);
        }
        [HttpPut("{id:int}")]
        public async Task<ApiResult<FavoriteFoodDomain>> Update(int id, [FromBody]  UpsertFavoriteFoodParams body)
        {
            var result = await favoriteFoodService.Update(id, body);
            return new ApiResult<FavoriteFoodDomain>().Succeed(result);
        }
        [HttpDelete("{id:int}")]
        public async Task<ApiResult<FavoriteFoodDomain>> Delete(int id)
        {
            var result = await favoriteFoodService.Delete(id);
            return new ApiResult<FavoriteFoodDomain>().Succeed(result);
        }
    }
}
