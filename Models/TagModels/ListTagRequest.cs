using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TagModels
{
    public class ListTagRequest
    {
        public PaginationParams Pagination {  get; set; }
        public SortParams Sort { get; set; }
        public TagFilterParams Filter { get; set; }
    }
}
