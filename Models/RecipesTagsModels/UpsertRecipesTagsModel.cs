using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RecipesTagsModels
{
    public class UpsertRecipesTagsModel
    {
        public long RecipeId { get; set; }
        public long TagId { get; set; }
    }
}
