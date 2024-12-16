using AutoMapper;
using Domain.RecipesTags;
using Infrastructure.Models;
using Infrastructure.Repositories.RecipesTagsRepo;
using Models.RecipesTagsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RecipesTagsServices
{
    public interface IRecipesTagsService
    {
        Task<RecipesTagsDomain> Add(UpsertRecipesTagsModel upsert);
    }
    public class RecipesTagService(IRecipesTagsRepository recipesTagsRepository, IMapper mapper) : IRecipesTagsService
    {
        public async Task<RecipesTagsDomain> Add(UpsertRecipesTagsModel upsert)
        {
            var entity = mapper.Map<RecipesTags>(upsert);
            var result = mapper.Map<RecipesTagsDomain>(entity);
            return result;
        }

    }
}
