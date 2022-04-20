using Bdv.Domain.Abstractions;
using Bdv.Domain.Abstractions.Sso;
using Bdv.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bdv.Sso.Domain.Entities
{
    public class User : EntityBase<Guid>, IUser
    {
        /// <summary>
        /// User login
        /// </summary>
        [Column("email")]
        public string? Email { get; set; }

        /// <summary>
        /// User phone
        /// </summary>
        [Column("phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// User login
        /// </summary>
        [Column("login")]
        public string? Login { get; set; }

        /// <summary>
        /// User hashed password
        /// </summary>
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// Password salt
        /// </summary>
        [Column("password_salt")]
        public string PasswordSalt { get; set; }

        /// <summary>
        /// If user should change password after next login
        /// </summary>
        [Column("is_need_change_password")]
        public bool? IsNeedChangePassword { get; set; }

        /// <summary>
        /// If user confirmed e-mail by code
        /// </summary>
        [Column("is_email_confirmed")]
        public bool? IsEmailConfirmed { get; set; }

        /// <summary>
        /// If user confirmed phone by sms/call
        /// </summary>
        [Column("is_phone_confirmed")]
        public bool? IsPhoneConfirmed { get; set; }
    }
}
