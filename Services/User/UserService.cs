using Domain.UserDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.User
{
    public class UserService:IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository) { 
            this.userRepository = userRepository;
        }

    }
}
