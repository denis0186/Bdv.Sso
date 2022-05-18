using Bdv.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bdv.Sso.Domain.Entities
{
    /// <summary>
    /// Role-permission relation
    /// </summary>
    [Table("role_permissions")]
    public class RolePermission : EntityBase<int>
    {
        /// <summary>
        /// Role identifier
        /// </summary>
        [Column("role_id")]
        public int RoleId { get; set; }

        /// <summary>
        /// Permission identifier
        /// </summary>
        [Column("permission_id")]
        public int PermissionId { get; set; }
    }
}
