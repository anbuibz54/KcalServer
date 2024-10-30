using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ActivityRateModels;
using Services.ActivityRate;

namespace KcalServer.Controllers.ActivityRate
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityRateController(IActivityRateService activityRateService):ControllerBase
    {
        [HttpGet("all")]
        public async Task<ApiResult<IList<ActivityRateModel>>> GetAll()
        {
            var res = await activityRateService.GetAll();
            return new ApiResult<IList<ActivityRateModel>>().Succeed(res);
        }
        [HttpPost("add")]
        public ApiResult<ActivityRateModel> Add(ActivityRateModel input)
        {
            return new ApiResult<ActivityRateModel>().Succeed(input);
        }
    }
}
