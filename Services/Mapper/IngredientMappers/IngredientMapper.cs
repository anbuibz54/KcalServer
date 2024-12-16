using AutoMapper;
using Domain.Ingredient;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.IngredientMappers
{
    public class IngredientMapper:Profile
    {
        public IngredientMapper() 
        {
            CreateMap<Ingredient, IngredientDomain>();
            CreateMap<IngredientDomain, Ingredient>();
        }
    }
}
