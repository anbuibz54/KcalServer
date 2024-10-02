using Domain.AuthDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.UserModels;
using Services.User;

namespace KcalServer.Controllers.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet, Authorize,Route("auth")]
        public IActionResult Auth() {
            return Ok("Valid");
        }
        [HttpPost, Route("register")]
        public async Task<IActionResult> Register(AuthInput input)
        {
            try
            {
                var res = await _userService.Register(input);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(AuthInput input)
        {
            try
            {
                var res = await _userService.Login(input);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost, Route("update-user-infor")]
        public async Task<IActionResult> UpdateUserInfor(UserInforModel input)
        {
            try
            {
                var res = await _userService.UpdateUserInfor(input);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
