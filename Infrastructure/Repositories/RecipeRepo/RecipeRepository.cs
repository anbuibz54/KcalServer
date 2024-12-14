using AutoMapper;
using Infrastructure.Models;
using Infrastructure.Repositories.RecipesTagsRepo;
using Microsoft.EntityFrameworkCore;
using Models.Common;
using Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.RecipeRepo
{
    public class RecipeRepository: BaseRepository<Recipe>, IRecipeRepository
    {
        private readonly IRecipesTagsRepository _recipesTagsRepository;
        private readonly IMapper _mapper;
        public RecipeRepository(CoreContext context, IRecipesTagsRepository recipesTagsRepository, IMapper mapper ) : base(context) 
        { 
            this._recipesTagsRepository = recipesTagsRepository;
            this._mapper = mapper;
        }

        public async Task<Recipe> AddAsync(UpsertRecipeRequest request)
        {
            var entity = _mapper.Map<Recipe>( request );
            entity = await this.AddAsync( entity );
            var listTags = request.TagIds.Select(tagId => new RecipesTags() { RecipeId =entity.Id, TagId =tagId }).ToList();
            await _recipesTagsRepository.AddRange( listTags );
            listTags = (await _recipesTagsRepository.GetAllByRecipeId(entity.Id)).ToList();
            entity.RecipesTags = listTags;
            return entity;
        }

        public async Task<PaginationResponse<Recipe>> GetAll(PaginationParams pagination, SortParams sort, RecipeFilterParams filter)
        {
            var query = _DbSet.Include(r => r.RecipesTags).AsQueryable();
            ApplyFilters(filter, query);
            ApplySorting(query, sort);
            ApplyPagination(query, pagination);
            var totalCounts = await query.CountAsync();
            var data = await query.ToListAsync();
            var result = new PaginationResponse<Recipe>() { Data = data, PageNumber = pagination.PageNumber, PageSize = pagination.PageSize, TotalCount = totalCounts, TotalPage = (totalCounts / pagination.PageSize) + 1 };
            return result;

        }

        public Task<Recipe> UpdateAsync(UpsertRecipeRequest request)
        {
            throw new NotImplementedException();
        }

        private IQueryable<Recipe> ApplyFilters(RecipeFilterParams filter, IQueryable<Recipe> query) {

            if (!String.IsNullOrEmpty(filter.Name)) {
                query = query.Where(r => r.Title.Contains(filter.Name));
            }
            if(filter.TagId > 0 )
            {
                query = query.Where(r => r.RecipesTags.Any(rt => rt.TagId == filter.TagId));
            }
            return query;
        }
    }
}
