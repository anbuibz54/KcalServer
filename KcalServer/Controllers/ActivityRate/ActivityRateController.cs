using Microsoft.AspNetCore.Mvc;
using Services.ActivityRate;

namespace KcalServer.Controllers.ActivityRate
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityRateController(IActivityRateService activityRateService):ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var res = await activityRateService.GetAll();
            return Ok(res);
        }
    }
}
