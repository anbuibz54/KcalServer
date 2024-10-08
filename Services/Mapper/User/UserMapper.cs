using AutoMapper;
using UserDomain =Domain.UserDomain.User;
using UserEntity =Infrastructure.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.AuthDomain;
using Models.UserModels;

namespace Services.Mapper.User
{
    public class UserMapper:Profile
    {
        public UserMapper() {
            CreateMap<UserDomain, UserEntity>();
            CreateMap<UserEntity, UserDomain>();
            CreateMap<UserDomain,UserInforModel>();
            CreateMap<UserInforModel, UserDomain>();
            CreateMap<UserDomain,UserInforResponse>();
            CreateMap<AuthInput,UserDomain>();
            CreateMap<UserDomain, AuthResponse>();
        }
    }
}
