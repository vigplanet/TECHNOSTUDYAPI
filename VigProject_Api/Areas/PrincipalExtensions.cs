using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VigProject_Api
{
    public static class PrincipalExtensions
    {
        public static int GetMsrno(this ClaimsPrincipal principal)
        {
            var Msrno = principal != null ? Convert.ToInt32(principal.FindFirst("Msrno")?.Value) : 0;
            return Msrno > 0 ? Msrno : 0;
        }
    }
}
