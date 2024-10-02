using Domain.AuthDomain;
using Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDomain = Domain.UserDomain.User;
namespace Services.User
{
    public interface IUserService
    {
        public Task<AuthResponse> Register(AuthInput user);
        public Task<AuthResponse> Login(AuthInput user);
        public Task  Auth(string token);
        public Task<UserInforResponse> UpdateUserInfor(UserInforModel user);
    }
}
