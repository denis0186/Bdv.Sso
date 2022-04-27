namespace Bdv.Sso.Common
{
    /// <summary>
    /// Token generator settings
    /// </summary>
    public interface ITokenGeneratorSettings
    {
        /// <summary>
        /// RSA private key
        /// </summary>
        public string RsaPrivateKey { get; }

        /// <summary>
        /// RSA public key
        /// </summary>
        public string RsaPublicKey { get; }

        /// <summary>
        /// Audience
        /// </summary>
        string Audience { get; }

        /// <summary>
        /// Issuer
        /// </summary>
        string Issuer { get; }

        /// <summary>
        /// Access token expiry (seconds)
        /// </summary>
        int AccessTokenExpiry { get; }
    }
}
