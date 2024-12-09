using AutoMapper;
using Domain.FavoriteFood;
using Infrastructure.Models;
using Models.Common;
using Models.FavoriteFoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.FavoriteFoodMappers
{
    public class FavoriteFoodMapper: Profile
    {
        public FavoriteFoodMapper() {
            CreateMap<FavoriteFood,FavoriteFoodDomain>();
            CreateMap<FavoriteFoodDomain,FavoriteFood>();
            CreateMap<UpsertFavoriteFoodParams,FavoriteFood>();
            CreateMap<PaginationResponse<FavoriteFood>,PaginationResponse<FavoriteFoodDomain>>();
        }
    }
}
