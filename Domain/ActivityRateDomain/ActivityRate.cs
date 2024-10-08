using Domain.UserDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ActivityRateDomain
{
    public class ActivityRate
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double? Value { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
