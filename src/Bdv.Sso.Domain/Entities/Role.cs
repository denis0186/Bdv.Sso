using Bdv.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdv.Sso.Domain.Entities
{
    /// <summary>
    /// Role entity
    /// </summary>
    [Table("roles")]
    public class Role : EntityBase<int>
    {
        /// <summary>
        /// Role name
        /// </summary>
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Role description
        /// </summary>
        [Column("description")]
        public string Description { get; set; } = string.Empty;
    }
}
