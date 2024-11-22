using AutoMapper;
using Domain.Food;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.FoodMappers
{
    public class FoodMapper:Profile
    {
        public FoodMapper() {
            CreateMap<Food,FoodDomain>();
            CreateMap<FoodDomain,Food>();
        }
    }
}
