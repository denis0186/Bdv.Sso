using Bdv.Sso.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bdv.Sso.DataAccess
{
    public class SsoContext : DbContext
    {
        public SsoContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(x => x.Id);
        }
    }
}
