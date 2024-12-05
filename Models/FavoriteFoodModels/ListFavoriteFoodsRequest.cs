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
        public PaginationParams? PaginationParams {  get; set; }
        public SortParams? SortParams { get; set; }
        public FavoriteFoodFilterParams? FilterParams { get; set; }
    }
}
