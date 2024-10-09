using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Claims
{
    public interface IClaimService
    {
        public int GetUserId();
        public string GetClaimValue(string claimName);
    }
}
