using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Models.Common;
using Models.FavoriteFoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.FavoriteFoodRepo
{
    public class FavoriteFoodRepository : BaseRepository<FavoriteFood>, IFavoriteFoodRepository
    {
        public FavoriteFoodRepository(CoreContext context) : base(context) { }

        public async Task<PaginationResponse<FavoriteFood>> GetAllAsync(PaginationParams pagination, SortParams sortParams, FavoriteFoodFilterParams filterParams)
        {
            var query = _DbSet.AsQueryable();
            query = ApplyFilters(query, filterParams);
            query = ApplySorting(query, sortParams);
            query = ApplyPagination(query, pagination);
            var totalCounts = await query.CountAsync();
            var data = await query.ToListAsync();
            PaginationResponse<FavoriteFood> result = new PaginationResponse<FavoriteFood>() { Data = data, PageNumber = pagination.PageNumber, PageSize = pagination.PageSize, TotalCount = totalCounts, TotalPage = (totalCounts / pagination.PageSize) + 1 };
            return result;
        }

        private IQueryable<FavoriteFood> ApplyFilters(IQueryable<FavoriteFood> query, FavoriteFoodFilterParams filterParams)
        {
            if (!String.IsNullOrEmpty(filterParams.Name))
            {
                query = query.Where(e => e.Food != null && e.Food.Name == filterParams.Name);
            }
            return query;
        }
    }
}
