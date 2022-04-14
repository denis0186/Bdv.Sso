using System.ComponentModel.DataAnnotations.Schema;

namespace Bdv.Sso.Domain.Entities
{
    public class User
    {
        /// <summary>
        /// User login
        /// </summary>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        /// User phone
        /// </summary>
        [Column("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// User login
        /// </summary>
        [Column("login")]
        public string Login { get; set; }
    }
}
