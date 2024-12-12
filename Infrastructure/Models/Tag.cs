using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Thumbnail { get; set; }
        public virtual ICollection<RecipesTags> RecipesTags { get; set; } = new List<RecipesTags>();
        public void Update(Tag e)
        {
            foreach (var item in e.GetType().GetProperties())
            {
                if (item.Name == "Id") continue;
                if (item.PropertyType == typeof(int) && item.GetValue(e).ToString() == "0") continue;
                if (item.PropertyType == typeof(double) && item.GetValue(e).ToString() == "0") continue;
                if (item.GetValue(e) == null) continue;
                this.GetType().GetProperty(item.Name).SetValue(this, item.GetValue(e));
            }
        }
    }
}
