using Microsoft.EntityFrameworkCore;
using Unnise.Domain.Entities;

namespace Unnise.Infrastructure.Persistence
{
    public class UnniseDbContext(DbContextOptions<UnniseDbContext> options) : DbContext(options)
    {
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<ProjectMember> ProjectMembers => Set<ProjectMember>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UnniseDbContext).Assembly);
        }
    }
}
