using Domain.Common;
using Infrastructure.Models;
using Models.Common;
using Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.FoodRepo
{
    public interface IFoodRepository:IBaseRepository<Food>
    {
        public Task<PaginationResponse<Food>> GetAllAsync(PaginationParams paginationParams, FoodFilterParams foodFilterParams, SortParams sortParams);
    }
}
