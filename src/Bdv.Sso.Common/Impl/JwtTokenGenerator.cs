using Bdv.Common;
using Bdv.Sso.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Bdv.Sso.Common.Impl
{
    public class JwtTokenGenerator : ITokenGenerator
    {
        private readonly ITokenGeneratorSettings _settings;
        private readonly IRsaKeyReader _rsaKeyReader;

        public JwtTokenGenerator(
            ITokenGeneratorSettings settings,
            IRsaKeyReader rsaKeyReader)
        {
            _settings = settings;
            _rsaKeyReader = rsaKeyReader;
        }

        public async Task<string> GenerateAccessTokenAsync(User user)
        {
            var key = await _rsaKeyReader.GetPrivateKeyAsync(_settings.RsaPrivateKey);
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
