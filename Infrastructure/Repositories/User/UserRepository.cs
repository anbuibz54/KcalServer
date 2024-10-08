using Domain.UserDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Models;
using UserEntity = Infrastructure.Models.User;
using UserDomain = Domain.UserDomain.User;
namespace Infrastructure.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly CoreContext _coreContext;
        private readonly IMapper _mapper;
        public UserRepository(CoreContext coreContext,IMapper mapper) { 
            _coreContext = coreContext;
            _mapper = mapper;
        }
        public async Task<UserDomain> AddAsync(UserDomain user)
        {
            var document =await _coreContext.Users.FirstOrDefaultAsync(u=>u.Email == user.Email);
            if (document != null) {
                return null;
            }
            var newEntity = _mapper.Map<UserEntity>(user);
            _coreContext.Users.Add(newEntity);
            _coreContext.SaveChanges();
            var res = _mapper.Map<UserDomain>(newEntity);
            return res;
        }

        public Task<IEnumerable<Domain.UserDomain.User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDomain> GetByEmailAsync(string email)
        {
            var document = await _coreContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (document != null)
            {
                var res = _mapper.Map<UserDomain>(document);
                return res;
            }
            return null;
        }

        public async Task<Domain.UserDomain.User> GetByIdAsync(int id)
        {
            var entity = await _coreContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (entity == null) { throw new Exception("User does not exist"); }
            return _mapper.Map<UserDomain>(entity);
        }

        public async Task<UserDomain> UpdateAsync(UserDomain user)
        {
            var entity = await _coreContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (entity == null) { throw new Exception("User does not exist"); }
            entity.Update(_mapper.Map<UserEntity>(user));
            _coreContext.SaveChanges();
            var res = _mapper.Map<UserDomain>(entity);
            return res;
        }
    }
}
