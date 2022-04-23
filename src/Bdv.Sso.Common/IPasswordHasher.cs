namespace Bdv.Sso.Common
{
    /// <summary>
    /// Password hash service
    /// </summary>
    public interface IPasswordHasher
    {
        /// <summary>
        /// Compute password hash
        /// </summary>
        /// <param name="password">Password string</param>
        /// <param name="salt">Password salt</param>
        /// <returns>Hash string</returns>
        string HashPassword(string password, out string salt);

        /// <summary>
        /// Validate password
        /// </summary>
        /// <param name="password">Password string</param>
        /// <param name="salt">Password salt</param>
        /// <param name="hash">Password hash string</param>
        /// <returns>Validation result</returns>
        bool ValidatePassword(string? password, string? salt, string? hash);
    }
}
