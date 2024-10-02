using Domain.ActivityRateDomain;
using Models.UserModels.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserDomain
{
    public class User
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public string? Phone { get; set; }

        public string Email { get; set; } = null;

        public string Password { get; set; } = null!;
        public float? Height { get; set; }

        public float? Weight { get; set; }

        public Gender? Gender { get; set; }
        public int? Age { get; set; }
        public long ActivityRateId { get; set; }
        
    }
}
