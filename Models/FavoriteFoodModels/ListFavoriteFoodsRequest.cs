using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FavoriteFoodModels
{
    public class ListFavoriteFoodsRequest
    {
        public PaginationParams? paginationParams {  get; set; }
        public SortParams? sortParams { get; set; }
        public FavoriteFoodFilterParams? filterParams { get; set; }
    }
}
