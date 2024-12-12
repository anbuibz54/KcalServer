using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tag
{
    public class TagDomain
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? Thumbnail { get; set; }
    }
}
