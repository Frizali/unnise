using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unnise.Domain.Entities;
using Unnise.Domain.Enums;

namespace Unnise.Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Visibility)
                .HasDefaultValue(ProjectVisibility.Public);

            builder.Property(x => x.CreatedAt)
                .IsRequired();
        }
    }
}
