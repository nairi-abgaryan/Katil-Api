using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Katil.Data.Model
{
    public sealed class AppDbContext : DbContext
    {
        #region Constructor

        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }

        #endregion

        #region DBSets

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        #endregion

        #region Fluent API

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new {Id = 1, Name = "ROLE_USER", RoleDescritption = "User role"},
                new {Id = 2, Name = "ROLE_ADMIN", RoleDescritption = "Role for staff users"});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        #endregion

        #region Private member methods

        #endregion
    }
}
