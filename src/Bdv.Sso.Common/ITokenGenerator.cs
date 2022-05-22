using Bdv.Sso.Domain.Entities;

namespace Bdv.Sso.Common
{
    public interface ITokenGenerator
    {
        /// <summary>
        /// Generate access token
        /// </summary>
        /// <param name="user">User</param>
        /// <returns></returns>
        Task<string> GenerateAccessTokenAsync(User user, IEnumerable<Role> roles, IEnumerable<Permission> permissions);

        /// <summary>
        /// Generate refresh token
        /// </summary>
        /// <returns></returns>
        Task<string> GenerateRefreshTokenAsync(User user);
    }
}
