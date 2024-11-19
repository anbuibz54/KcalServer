using AutoMapper;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public CoreContext _Context { get; set; }
        public DbSet<T> _DbSet { get; set; }

        public BaseRepository(CoreContext coreContext)
        {
            _Context = coreContext;
            _DbSet = coreContext.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            var result = await _DbSet.AddAsync(entity);
            await _Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            var result = _DbSet.Remove(entity);
            await _Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ICollection<T>> GetAllSync()
        {
            var result = await _DbSet.ToListAsync();
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await  _DbSet.FindAsync(id);
            if (entity == null) throw new Exception("Not Found");
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var result = _DbSet.Update(entity);
            await _Context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
