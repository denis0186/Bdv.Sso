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

        public string GenerateAccessTokenAsync(User user)
        {
            if (string.IsNullOrEmpty(_settings.RsaPrivateKey))
            {
                throw new ArgumentException("RSA private key wasn't provided");
            }

            var privateKey = Convert.FromBase64String(_settings.RsaPrivateKey);
            using var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(privateKey, out _);
            var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
            {
                CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
            };

            var now = DateTime.Now;
            var unixTimeSeconds = new DateTimeOffset(now).ToUnixTimeSeconds();

            var jwt = new JwtSecurityToken(
                audience: _settings.Audience,
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

        public string GenerateRefreshTokenAsync()
        {
            throw new NotImplementedException();
        }
    }
}
