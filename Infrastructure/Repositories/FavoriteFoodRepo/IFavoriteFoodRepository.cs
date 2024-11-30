using Domain.Common;
using Infrastructure.Models;
using Models.Common;
using Models.FavoriteFoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.FavoriteFoodRepo
{
    public interface IFavoriteFoodRepository: IBaseRepository<FavoriteFood>
    {
        public Task<PaginationResponse<FavoriteFood>> GetAllAsync(PaginationParams pagination, SortParams sortParams, FavoriteFoodFilterParams filterParams);
    }
}
