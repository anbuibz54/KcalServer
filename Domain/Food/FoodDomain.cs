using Domain.UserDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Food
{
    public class FoodDomain
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double? Calories { get; set; }

        public double? Fat { get; set; }

        public double? Protein { get; set; }

        public double? Carbohydrate { get; set; }

        public double? ServingWeight { get; set; }

        public string? ServingUnit { get; set; }
        public void Update(FoodDomain e)
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
