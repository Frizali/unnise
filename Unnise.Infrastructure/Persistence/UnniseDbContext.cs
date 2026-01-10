using Microsoft.EntityFrameworkCore;
using Unnise.Domain.Entities;

namespace Unnise.Infrastructure.Persistence
{
    public class UnniseDbContext(DbContextOptions<UnniseDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UnniseDbContext).Assembly);
        }
    }
}
