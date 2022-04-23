using System.Security.Cryptography;
using System.Text;

namespace Bdv.Sso.Common.Impl
{
    public class Md5PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password, out string salt)
        {
            _ = password ?? throw new ArgumentNullException(nameof(password));
            salt = Guid.NewGuid().ToString();
            return HashPassword(password, salt);
        }

        public bool ValidatePassword(string? password, string? salt, string? hash)
        {
            if (password == null && hash == null)
            {
                return true;
            }
            else if (password == null || hash == null)
            {
                return false;
            }

            return hash.Equals(HashPassword(password, salt), StringComparison.InvariantCulture);
        }

        private string HashPassword(string password, string? salt)
        {
            var hash = MD5.HashData(Encoding.Unicode.GetBytes($"{password}{salt}"));
            return Convert.ToBase64String(hash);
        }
    }
}
