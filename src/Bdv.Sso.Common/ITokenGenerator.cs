using Bdv.Sso.Domain.Entities;

namespace Bdv.Sso.Common
{
    public interface ITokenGenerator
    {
        string GenerateAccessTokenAsync(User user);

        string GenerateRefreshTokenAsync();
    }
}
