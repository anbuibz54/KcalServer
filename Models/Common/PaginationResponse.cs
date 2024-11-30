using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class PaginationResponse<T> where T : class
    {
        public List<T> Data { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage {  get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
