using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Bdv.Sso.Common.Cryptography
{
    public static class RsaHelper
    {
        /// <summary>
        /// Get private RSA parameters
        /// </summary>
        /// <param name="keyFile">Path to key file (xml)</param>
        /// <returns></returns>
        public static async Task<RsaSecurityKey> GetPrivateKeyAsync(string keyFile)
        {
            if (string.IsNullOrEmpty(keyFile) || !File.Exists(keyFile))
            {
                throw new ArgumentException("RSA private key wasn't provided");
            }

            var privateKey = await File.ReadAllTextAsync(keyFile);
            using var rsa = RSA.Create();
            rsa.FromXmlString(privateKey);

            return new RsaSecurityKey(rsa.ExportParameters(true));
        }

        /// <summary>
        /// Get public RSA parameters
        /// </summary>
        /// <param name="keyFile">Path to key file (xml)</param>
        /// <returns></returns>
        public static RsaSecurityKey GetPublicKey(string keyFile)
        {
            if (string.IsNullOrEmpty(keyFile) || !File.Exists(keyFile))
            {
                throw new ArgumentException("RSA public key wasn't provided");
            }

            var publicKey = File.ReadAllText(keyFile);
            using var rsa = RSA.Create();
            rsa.FromXmlString(publicKey);

            return new RsaSecurityKey(rsa.ExportParameters(false));
        }
    }
}
