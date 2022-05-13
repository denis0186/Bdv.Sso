using System.ComponentModel.DataAnnotations;

namespace Bdv.Sso.Commands.Account
{
    public class UserLoginByLoginRequest : UserLoginByPasswordRequestBase
    {
        /// <summary>
        /// User login
        /// </summary>
        [Required]
        public string? Login { get; set; }
    }
}
