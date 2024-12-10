using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class RecipesTags
    {
        public long RecipeId { get; set; }
        public long TagId { get; set; }
        public virtual Tag? Tag { get; set; }
        public virtual Recipe? Recipe { get; set; }
    }
}
