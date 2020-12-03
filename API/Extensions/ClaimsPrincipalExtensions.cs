using System.Linq;
using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string RetriveEmailFromClaimsPrincipal(this ClaimsPrincipal user)
        {
            return user?.Claims?.FirstOrDefault(c=>c.Type==ClaimTypes.Email)?.Value;
        }
    }
}