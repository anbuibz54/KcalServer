using Domain.AuthDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
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
        [HttpGet,Route("{id}")]
        public async Task<ApiResult<UserInforResponse>> GetById(int id)
        {
            var res = await _userService.GetById(id);
            return new ApiResult<UserInforResponse>().Succeed(res);
        }
        [HttpPost, Route("register")]
        public async Task<ApiResult<AuthResponse>> Register(AuthInput input)
        {
                var res = await _userService.Register(input);
                
                return new ApiResult<AuthResponse>().Succeed(res);
        }
        [HttpPost, Route("login")]
        public async Task<ApiResult<AuthResponse>> Login(AuthInput input)
        {
            var res = await _userService.Login(input);

            return new ApiResult<AuthResponse>().Succeed(res);
        }
        [HttpPost, Route("update-user-infor")]
        public async Task<ApiResult<UserInforResponse>> UpdateUserInfor(UserInforModel input)
        {
                var res = await _userService.UpdateUserInfor(input);
                return new ApiResult<UserInforResponse>().Succeed(res);
        }


    }
}
