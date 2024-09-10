using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AuthDomain
{
    public class AuthResponse
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public string? Phone { get; set; }

        public string Email { get; set; } = null;
        public string AccessToken { get; set; }

    }
}
