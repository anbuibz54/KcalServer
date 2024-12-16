using Infrastructure.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Tag: BaseEntity<Tag>
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Thumbnail { get; set; }
        public virtual ICollection<RecipesTags> RecipesTags { get; set; } = new List<RecipesTags>();
    }
}
