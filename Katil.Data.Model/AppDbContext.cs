using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Katil.UserResolverService;
using Microsoft.EntityFrameworkCore;

namespace Katil.Data.Model
{
    public sealed class AppDbContext : DbContext
    {        
        private readonly IUserResolver _userResolver;

        #region Constructor

        public AppDbContext(DbContextOptions<AppDbContext> options, IUserResolver userResolver)
                : base(options)
        {
            _userResolver = userResolver;
        }

        #endregion

        #region DBSets

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        #endregion

        #region Fluent API

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new {Id = 1, Name = "ROLE_USER", RoleDescritption = "User role"},
                new {Id = 2, Name = "ROLE_ADMIN", RoleDescritption = "Role for staff users"});
            
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
     
        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            {
                var userId = _userResolver.GetUserId();

                foreach (var entity in entities)
                {
                    if (entity.State == EntityState.Added)
                    {
                        ((BaseEntity)entity.Entity).CreatedDate = DateTime.UtcNow;
                        ((BaseEntity)entity.Entity).CreatedBy = userId;
                    }

                    ((BaseEntity)entity.Entity).ModifiedDate = DateTime.UtcNow;
                    ((BaseEntity)entity.Entity).ModifiedBy = userId;
                }
            }
        }
        #endregion

        #region Private member methods

        #endregion
    }
}
