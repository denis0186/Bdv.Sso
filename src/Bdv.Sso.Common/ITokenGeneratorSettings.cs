namespace Bdv.Sso.Common
{
    /// <summary>
    /// Token generator settings
    /// </summary>
    public interface ITokenGeneratorSettings
    {
        /// <summary>
        /// RSA private key (path to xml file)
        /// </summary>
        public string RsaPrivateKey { get; }

        /// <summary>
        /// Issuer
        /// </summary>
        string Issuer { get; }

        /// <summary>
        /// Access token expiry (seconds)
        /// </summary>
        int AccessTokenExpiry { get; }

        /// <summary>
        /// Refresh token expiry (days)
        /// </summary>
        int RefreshTokenExpiry { get; }
    }
}
