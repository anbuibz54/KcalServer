using Domain.Food;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Models.Common;
using Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.FoodRepo
{
    public class FoodRepository: BaseRepository<Food>, IFoodRepository
    {
        public FoodRepository(CoreContext context) : base(context) { }

        public async Task<PaginationResponse<Food>> GetAllAsync(PaginationParams pagination, FoodFilterParams filterParams, SortParams sortParams)
        {
            var query = _DbSet.AsQueryable();
            query = ApplyFilters(query, filterParams);
            query = ApplySorting(query, sortParams);
            query = ApplyPagination(query, pagination);
            var totalCounts = await query.CountAsync();
            var data = await query.ToListAsync();
            PaginationResponse<Food> result = new PaginationResponse<Food>() { Data = data, PageNumber = pagination.PageNumber, PageSize = pagination.PageSize, TotalCount = totalCounts, TotalPage = (totalCounts / pagination.PageSize) + 1 };
            return result;
        }
        private IQueryable<Food> ApplyFilters(IQueryable<Food> query, FoodFilterParams filterParams)
        {
            if (!String.IsNullOrEmpty(filterParams.Name))
            {
                query = query.Where(e => e.Name.Contains(filterParams.Name));
            }
            return query;
        }
    }
}
