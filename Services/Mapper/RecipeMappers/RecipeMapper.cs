using AutoMapper;
using Domain.Recipe;
using Infrastructure.Models;
using Models.Common;
using Models.RecipeModels;
using Newtonsoft.Json;
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
            CreateMap<Recipe, RecipeDomain>()
                .ForMember(des => des.Instruction, src => src.MapFrom(m => new RecipeInstructionModel(m.Instruction)));
            CreateMap<RecipeDomain, Recipe>();
            CreateMap<UpsertRecipeRequest, Recipe>()
                .ForMember(des => des.Ingredients, src => src.Ignore())
                .ForMember(des => des.Instruction, src => src.MapFrom(m => JsonConvert.SerializeObject(m.Instructions)));
            CreateMap<PaginationResponse<Recipe>, PaginationResponse<RecipeDomain>>();
        }
    }
}
