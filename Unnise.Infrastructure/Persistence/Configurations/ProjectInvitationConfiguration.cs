using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unnise.Domain.Entities;

namespace Unnise.Infrastructure.Persistence.Configurations
{
    public class ProjectInvitationConfiguration : IEntityTypeConfiguration<ProjectInvitation>
    {
        public void Configure(EntityTypeBuilder<ProjectInvitation> builder)
        {
            builder.ToTable("ProjectInvitations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProjectId)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.Role)
                .IsRequired();

            builder.Property(x => x.Token)
                .IsRequired();

            builder.Property(x => x.ExpiredAt);

            builder.Property(x => x.Status);
        }
    }
}
