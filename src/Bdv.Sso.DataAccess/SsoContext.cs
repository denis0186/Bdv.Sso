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

            //Model
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasMany<UserRole>().WithOne().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Role>().HasKey(x => x.Id);
            modelBuilder.Entity<Role>().HasMany<UserRole>().WithOne().HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Role>().HasMany<RolePermission>().WithOne().HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Permission>().HasKey(x => x.Id);
            modelBuilder.Entity<Permission>().HasMany<RolePermission>().WithOne().HasForeignKey(x => x.PermissionId).OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<UserRole>().HasKey(x => x.Id);
            modelBuilder.Entity<RolePermission>().HasKey(x => x.Id);

            //Data
            var adminUser = new User { Id = Guid.NewGuid(), Login = "admin", IsNeedChangePassword = true };
            var superAdminRole = new Role { Id = 1, Name = "SuperAdmin", Description = "Super admin" };
            var serviceAdminRole = new Role { Id = 2, Name = "ServiceAdmin", Description = "Service admin" };
            var adminUserSuperAdminRole = new UserRole { Id = 1, UserId = adminUser.Id, RoleId = superAdminRole.Id };
            modelBuilder.Entity<User>().HasData(new[] { adminUser });
            modelBuilder.Entity<Role>().HasData(new[] { superAdminRole, serviceAdminRole });
            modelBuilder.Entity<UserRole>().HasData(new[] { adminUserSuperAdminRole });

        }
    }
}
