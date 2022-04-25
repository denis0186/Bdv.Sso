using Bdv.Sso.Domain.Entities;

namespace Bdv.Sso.Common
{
    public interface ITokenGenerator
    {
        Task<string> GenerateAccessTokenAsync(User user);

        Task<string> GenerateRefreshTokenAsync(User user, string accessToken);
    }
}
