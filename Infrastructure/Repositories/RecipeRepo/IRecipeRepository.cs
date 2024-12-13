using Domain.Common;
using Infrastructure.Models;
using Models.Common;
using Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.RecipeRepo
{
    public interface IRecipeRepository: IBaseRepository<Recipe>
    {
        Task<PaginationResponse<Recipe>> GetAll(PaginationParams pagination, SortParams sort, RecipeFilterParams filter);
    }
}
