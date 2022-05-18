using Bdv.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bdv.Sso.Domain.Entities
{
    /// <summary>
    /// User-Role relation
    /// </summary>
    [Table("user_roles")]
    public class UserRole : EntityBase<int>
    {
        /// <summary>
        /// User identifier
        /// </summary>
        [Column("user_id")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Role identifier
        /// </summary>
        [Column("role_id")]
        public int RoleId { get; set; }
    }
}
