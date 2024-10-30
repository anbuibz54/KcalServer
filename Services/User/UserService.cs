using AutoMapper;
using Domain.AuthDomain;
using Domain.UserDomain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserDomain = Domain.UserDomain.User;
using BC = BCrypt.Net.BCrypt;
using Models.UserModels;
using UserEntity =Infrastructure.Models.User;
using Domain.ActivityRateDomain;
using Models.ActivityRateModels;
namespace Services.User
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IActivityRateRepository _activityRateRepository;
        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration,IActivityRateRepository activityRateRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _configuration = configuration;
            _activityRateRepository = activityRateRepository;
        }

        public Task Auth(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<UserInforResponse> UpdateUserInfor(UserInforModel user)
        {
            var domain = _mapper.Map<UserDomain>(user);
            var updatedUser = await _userRepository.UpdateAsync(domain);
            var activity = await _activityRateRepository.GetAsync((int)user.ActivityRateId);
            var res = _mapper.Map<UserInforResponse>(updatedUser);
            res.Tdee = await CalculateUserTdee(user);
            return res;

        }

        public async Task<AuthResponse> Login(AuthInput user)
        {
            var document = await _userRepository.GetByEmailAsync(user.Email);
            if (document == null) {
                throw new Exception("User does not exist");
            }
            var isPassValid = BC.Verify(user.Password, document.Password);
            if (!isPassValid) {
                throw new Exception("Wrong Password");
            }
            var res = _mapper.Map<AuthResponse>(document);
            res.AccessToken = CreateToken(res.Id);
            return res;

        }

        public async Task<AuthResponse> Register(AuthInput user)
        {
            var entity = _mapper.Map<UserDomain>(user);
            entity.Password= BC.HashPassword(user.Password);
            var newUser = await _userRepository.AddAsync(entity);
            if (newUser == null) {
                throw new Exception("User Existed");
            }
            var res = _mapper.Map<AuthResponse>(newUser);
            res.AccessToken = CreateToken(res.Id);
            return res;
        }
        private string CreateToken(long Id)
        {

            List<Claim> claims = new()
            {
                //list of Claims - we only checking username - more claims can be added.
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(Id)),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: cred
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        public async Task<double> CalculateUserTdee(UserInforModel user)
        {
            double bmr = 0;
            switch (user.Gender)
            {
                case Models.UserModels.Enums.Gender.Male:
                    {
                        bmr = 88.362 + (13.397 * user.Weight.Value) + (4.799 * user.Height.Value) - (5.677 * user.Age.Value);
                        break;
                    }
                case Models.UserModels.Enums.Gender.Female:
                    {
                        bmr = 447.593 + (9.247 * user.Weight.Value) + (3.098 * user.Height.Value) - (4.330 * user.Age.Value);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            var activity = await _activityRateRepository.GetAsync((int)user.ActivityRateId);
            var tdee = activity.Value * bmr;
            return tdee.Value;
        }

        public async Task<UserInforResponse> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var res = _mapper.Map<UserInforResponse>(user);
            return res;
        }
    }
}
