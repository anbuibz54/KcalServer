using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Claims
{
    public class ClaimService : IClaimService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClaimService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetClaimValue(string claimName)
        {
            var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
            if (claimsPrincipal == null)
            {
                return null;
            }

            var claim = claimsPrincipal.FindFirst(claimName)?.Value;
            return claim!;
        }

        public int GetUserId()
        {
            var Id = this.GetClaimValue(ClaimTypes.NameIdentifier);
            return int.Parse(Id);
        }
    }
}
