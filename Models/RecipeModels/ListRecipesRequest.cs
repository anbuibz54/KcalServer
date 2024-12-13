using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RecipeModels
{
    public class ListRecipesRequest
    {
        public PaginationParams? Pagination {  get; set; }
        public SortParams? Sort { get; set; }
        public RecipeFilterParams? Filter { get; set; }
    }
}
