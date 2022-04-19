using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdv.Sso.DataAccess
{
    public class SsoContext : DbContext
    {
        public SsoContext(DbContextOptions options) : base(options)
        {
        }
    }
}
