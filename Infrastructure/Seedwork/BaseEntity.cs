using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seedwork
{
    public abstract class BaseEntity<T> where T : class
    {
        public long Id { get; set; }
        public void Update(T e)
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
