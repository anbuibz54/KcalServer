using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class SortParams
    {
        public List<SortParam>? Params { get; set; }
    }
    public class SortParam
    {
        public string SortKey { get; set; } = string.Empty;
        public bool IsDesc { get; set; }
    }
}
