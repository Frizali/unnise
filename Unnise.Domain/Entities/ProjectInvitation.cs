using Unnise.Domain.Enums;

namespace Unnise.Domain.Entities
{
    public class ProjectInvitation : BaseEntity
    {
        public Guid ProjectId { get; private set; }
        public Guid UserId { get; private set; }
        public string Role { get; private set; } = null!;
        public string Token { get; private set; } = null!;
        public DateTime ExpiredAt { get; private set; }
        public InvitationStatus Status { get; private set; }

        public ProjectInvitation(
            Guid id,
            Guid projectId,
            Guid userId,
            string role,
            int expiresInDays
        ) : base(id)
        {
            ProjectId = projectId;
            UserId = userId;
            Role = role;
            Token = Guid.NewGuid().ToString("N");
            ExpiredAt = DateTime.UtcNow.AddDays(expiresInDays);
            Status = InvitationStatus.Pending;
        }

        private ProjectInvitation() : base(Guid.Empty) { }
    }
}
