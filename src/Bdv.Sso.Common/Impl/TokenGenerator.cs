using Bdv.Common;
using Bdv.Sso.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Bdv.Sso.Common.Impl
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly ITokenGeneratorSettings _settings;
        private readonly IRsaKeyReader _rsaKeyReader;

        public TokenGenerator(
            ITokenGeneratorSettings settings,
            IRsaKeyReader rsaKeyReader,
            IRedisRepository)
        {
            _settings = settings;
            _rsaKeyReader = rsaKeyReader;
        }

        public async Task<string> GenerateAccessTokenAsync(User user, IEnumerable<Role> roles, IEnumerable<Permission> permissions)
        {
            var key = await _rsaKeyReader.GetPrivateKeyAsync(_settings.RsaPrivateKey);
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256)
            {
                CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
            };

            var now = DateTime.UtcNow;
            var unixTimeSeconds = new DateTimeOffset(now).ToUnixTimeSeconds();

            var jwt = new JwtSecurityToken(
                audience: $"user:{user.Id}",
                issuer: _settings.Issuer,
                claims: new Claim[] {
                    new Claim(JwtRegisteredClaimNames.Iat, unixTimeSeconds.ToString(), ClaimValueTypes.Integer64),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("roles", string.Join(",", roles.Select(x => x.Name).ToArray())),
                    new Claim("permissions", string.Join(",", permissions.Select(x => x.Name).ToArray()))
                },
                expires: now.AddSeconds(_settings.AccessTokenExpiry),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<string> GenerateRefreshTokenAsync(User user)
        {
            await _redisRepository.SetAsync(
                $"refresh_token:{refreshToken}:string",
                new UserLoginInfoDto { UserId = user.Id, UserAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"] },
                TimeSpan.FromDays(7));

            return Guid.NewGuid().ToString().Replace("-", string.Empty);
        }
    }
}
