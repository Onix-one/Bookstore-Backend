using System.Security.Claims;

namespace Bookstore.IdentityApi.Interfaces
{
    public interface IJwtTokenService
    {
        public string GenerateJwtToken(ClaimsIdentity claimsIdentity);
    }
}
