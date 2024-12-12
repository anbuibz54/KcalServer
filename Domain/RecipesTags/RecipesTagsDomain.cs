using Domain.Recipe;
using Domain.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RecipesTags
{
    public class RecipesTagsDomain
    {
        public long RecipeId { get; set; }
        public long TagId { get; set; }
        public virtual TagDomain? Tag { get; set; }
        public virtual RecipeDomain? Recipe { get; set; }
    }
}
