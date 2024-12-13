using AutoMapper;
using Domain.Recipe;
using Infrastructure.Models;
using Models.Common;
using Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.RecipeMappers
{
    public class RecipeMapper: Profile
    {
        public RecipeMapper() {
            CreateMap<Recipe, RecipeDomain>();
            CreateMap<RecipeDomain, Recipe>();
            CreateMap<UpsertRecipeRequest, Recipe>();
            CreateMap<PaginationResponse<Recipe>, PaginationResponse<RecipeDomain>>();
        }
    }
}
