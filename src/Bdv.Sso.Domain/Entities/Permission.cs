using Bdv.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bdv.Sso.Domain.Entities
{
    /// <summary>
    /// Permission entity
    /// </summary>
    [Table("permissions")]
    public class Permission : EntityBase<int>
    {
        /// <summary>
        /// Permission name
        /// </summary>
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Permission description
        /// </summary>
        [Column("description")]
        public string Description { get; set; } = string.Empty;
    }
}
