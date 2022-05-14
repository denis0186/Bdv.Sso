using Bdv.Sso.Common.Cryptography;
using Bdv.Sso.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Bdv.Sso.Common.Impl
{
    public class JwtTokenGenerator : ITokenGenerator
    {
        private readonly ITokenGeneratorSettings _settings;

        public JwtTokenGenerator(ITokenGeneratorSettings settings)
        {
            _settings = settings;
        }

        public async Task<string> GenerateAccessTokenAsync(User user)
        {
            var key = await RsaHelper.GetPrivateKeyAsync(_settings.RsaPrivateKey);
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256)
            {
                CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
            };

            var now = DateTime.Now;
            var unixTimeSeconds = new DateTimeOffset(now).ToUnixTimeSeconds();

            var jwt = new JwtSecurityToken(
                audience: $"user:{user.Id}",
                issuer: _settings.Issuer,
                claims: new Claim[] {
                    new Claim(JwtRegisteredClaimNames.Iat, unixTimeSeconds.ToString(), ClaimValueTypes.Integer64),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                },
                notBefore: now,
                expires: now.AddSeconds(_settings.AccessTokenExpiry),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }
    }
}
