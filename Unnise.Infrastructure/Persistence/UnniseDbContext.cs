using Microsoft.EntityFrameworkCore;
using Unnise.Domain.Entities;

namespace Unnise.Infrastructure.Persistence
{
    public class UnniseDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public UnniseDbContext(DbContextOptions<UnniseDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UnniseDbContext).Assembly);
        }
    }
}
