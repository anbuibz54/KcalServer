using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Models.Common;
using Models.FoodModels;
using Models.TagModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.TagRepo
{
    public class TagRepository: BaseRepository<Tag>,ITagRepository
    {
        public TagRepository(CoreContext context) : base(context) { }

        public async Task<PaginationResponse<Tag>> GetAll(PaginationParams pagination, SortParams sort, TagFilterParams filter)
        {
            var query = _DbSet.AsQueryable();
            ApplyFilters(query, filter);
            ApplySorting(query, sort);
            ApplyPagination(query, pagination);
            var totalCounts = await query.CountAsync();
            var data = await query.ToListAsync();
            var res = new PaginationResponse<Tag>() { Data = data, PageNumber = pagination.PageNumber, PageSize = pagination.PageSize, TotalCount = totalCounts, TotalPage = (totalCounts / pagination.PageSize) + 1 };
            return res;
        }
        private IQueryable<Tag> ApplyFilters(IQueryable<Tag> query, TagFilterParams filterParams)
        {
            if (!String.IsNullOrEmpty(filterParams.Name))
            {
                query = query.Where(e => e.Name.Contains(filterParams.Name));
            }
            return query;
        }
    }
}
