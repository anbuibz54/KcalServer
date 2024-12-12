using Domain.Tag;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;
using Models.TagModels;
using Services.TagServices;

namespace KcalServer.Controllers.Tag
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController(ITagService tagService):ControllerBase
    {
        [HttpPost("all-page")]
        public async Task<ApiResult<PaginationResponse<TagDomain>>> GetAll([FromBody] ListTagRequest request) {
            var result =await tagService.GetAll(request.Pagination, request.Sort, request.Filter);
            return new ApiResult<PaginationResponse<TagDomain>>().Succeed(result);
        }
        [HttpPost("add")]
        public async Task<ApiResult<TagDomain>> Add([FromBody] UpsertTagModel tagModel)
        {
            var result = await tagService.Add(tagModel);
            return new ApiResult<TagDomain>().Succeed(result);
        }
        [HttpPut("{id:long}")]
        public async Task<ApiResult<TagDomain>> Update(long id,[FromBody] UpsertTagModel tagModel)
        {
            var result = await tagService.Update(id,tagModel);
            return new ApiResult<TagDomain>().Succeed(result);
        }
        [HttpDelete("{id:long}")]
        public async Task<ApiResult<TagDomain>> Delete(long id)
        {
            var result = await tagService.Delete(id);
            return new ApiResult<TagDomain>().Succeed(result);
        }
    }
}
