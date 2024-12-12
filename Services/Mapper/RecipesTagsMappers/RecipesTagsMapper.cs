using AutoMapper;
using Domain.RecipesTags;
using Infrastructure.Models;
using Models.RecipesTagsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.RecipesTagsMappers
{
    public class RecipesTagsMapper: Profile
    {
        public RecipesTagsMapper() {
            CreateMap<RecipesTags, RecipesTagsDomain>();
            CreateMap<RecipesTagsDomain, RecipesTags>();
            CreateMap<UpsertRecipesTagsModel, RecipesTags>();
        }
    }
}
