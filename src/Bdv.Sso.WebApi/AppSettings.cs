using Bdv.Authentication;
using Bdv.Sso.Common;
using Microsoft.Extensions.Configuration;

namespace Bdv.Sso.WebApi
{
    public class AppSettings : ITokenGeneratorSettings,  ITokenValidationSettings
    {
        public AppSettings(IConfiguration configuration)
        {
            RsaPublicKey = configuration["Token:RsaPublicKey"];
            RsaPrivateKey = configuration["Token:RsaPrivateKey"];
            Issuer = configuration["Token:Issuer"];
            AccessTokenExpiry = int.TryParse(configuration["Token:AccessTokenExpiry"], out var tokenExpiry) ? tokenExpiry : default;
        }

        public string RsaPrivateKey { get; }

        public string Issuer { get; }

        public int AccessTokenExpiry { get; }

        public string RsaPublicKey { get; }
    }
}
