using Domain;

namespace Business_Logic.Services.Auth
{
    public interface ITokenService
    {
        string GenerateAccessToken(ApplicationUser user);
        string GenerateRefreshToken();
        DateTime GetAccessTokenExpiry();
    }
}
