using System;
using System.Collections.Generic;
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

        public string? Email { get; set; }

        public string Password { get; set; } = null!;
    }
}
