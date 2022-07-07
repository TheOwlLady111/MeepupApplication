using System.Security.Claims;

namespace Business.Services
{
    public interface ITokenService
    {
        string GenerateJwt(IEnumerable<Claim> claims);
        Claim GetClaimFromJwt(string jwt, string claimType);
    }
}
