using System;
using System.Security.Claims;

namespace Aliquota.WebApp.Extensions {
    public static class ClaimsPrincipalExtensions {
        public static Guid GetUserId(this ClaimsPrincipal claims) {
            return Guid.Parse(claims.FindFirst(c => c.Type == ClaimTypes.PrimarySid).Value.ToString());
        }
    }
}