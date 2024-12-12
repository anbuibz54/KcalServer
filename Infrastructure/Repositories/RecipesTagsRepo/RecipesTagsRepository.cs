using Domain.RecipesTags;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.RecipesTagsRepo
{
    public class RecipesTagsRepository: BaseRepository<RecipesTags>, IRecipesTagsRepository
    {
        public RecipesTagsRepository(CoreContext context) : base(context) { }
    }
}
