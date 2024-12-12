using Domain.Common;
using Domain.RecipesTags;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.RecipesTagsRepo
{
    public interface IRecipesTagsRepository: IBaseRepository<RecipesTags>
    {
    }
}
