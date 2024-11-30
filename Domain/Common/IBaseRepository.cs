using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<T> GetByIdAsync(long id);
        public Task<ICollection<T>> GetAllSync();
        public Task<T> AddAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<T> DeleteAsync(T entity);
        public IQueryable<T> ApplyPagination<T>(IQueryable<T> query, PaginationParams pagination);
        public IQueryable<T> ApplySorting<T>(IQueryable<T> query, SortParams sortParams);
    }
}
