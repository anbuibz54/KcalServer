using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.RecipeModels
{
    public class RecipeFilterParams
    {
        public string? Name { get; set; }
        public int? TagId { get; set; }
        public double? Kcal {  get; set; } 

    }
}
