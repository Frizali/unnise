using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unnise.Domain.Entities;

namespace Unnise.Infrastructure.Persistence.Configurations
{
    public class ProjectMemberConfiguration : IEntityTypeConfiguration<ProjectMember>
    {
        public void Configure(EntityTypeBuilder<ProjectMember> builder)
        {
            builder.ToTable("ProjectMembers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProjectID)
                .IsRequired();

            builder.Property(x => x.UserID)
                .IsRequired();

            builder.Property(x => x.Role)
                .IsRequired();

            builder.Property(x => x.JoinedAt)
                .IsRequired();
        }
    }
}
