using AutoMapper;
using Domain.Common;
using Infrastructure.Seedwork;
using Microsoft.EntityFrameworkCore;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity<T>
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

        public async Task<T> GetByIdAsync(long id)
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

        public IQueryable<T1> ApplyPagination<T1>(IQueryable<T1> query, PaginationParams pagination)
        {
            query = query.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize);
            return query;
        }

        public IQueryable<T1> ApplySorting<T1>(IQueryable<T1> query, SortParams sortParams)
        {
            if(sortParams != null && sortParams.Params != null && sortParams.Params.Count >0)
            {
                foreach(var sortParam in sortParams.Params)
                {
                    if (sortParam.IsDesc)
                    {
                        query = query.OrderByDescending(e => e.GetType().GetProperty(sortParam.SortKey));
                    }
                    else
                    {
                        query = query.OrderBy(e => e.GetType().GetProperty(sortParam.SortKey));
                    }
                }
            }
            return query;
        }

        public async Task<ICollection<T>> GetByIdsAsync(List<long> ids)
        {
            if (ids == null || ids.Count == 0) return [];
            var entities = await _DbSet.Where(e => ids.Contains(e.Id)).ToListAsync();
            return entities;
        }
    }
}
