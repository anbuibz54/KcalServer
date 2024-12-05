using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FoodModels
{
    public class ListFoodsRequest
    {
        public PaginationParams PaginationParams { get; set; }
        public SortParams SortParams { get; set; }
        public FoodFilterParams FoodFilterParams { get; set; }
    }
}
