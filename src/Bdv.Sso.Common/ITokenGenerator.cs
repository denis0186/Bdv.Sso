using Bdv.Sso.Domain.Entities;

namespace Bdv.Sso.Common
{
    public interface ITokenGenerator
    {
        Task<string> GenerateTokenAsync(User user);
    }
}
