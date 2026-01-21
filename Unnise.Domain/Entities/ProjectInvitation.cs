using Unnise.Domain.Enums;

namespace Unnise.Domain.Entities
{
    public class ProjectInvitation(Guid id, Guid projectId, string identity, string role, int expiresInDays) : BaseEntity(id)
    {
        public Guid ProjectId { get; private set; } = projectId;
        public string Identity { get; private set; } = identity;
        public string Role { get; private set; } = role;
        public string Token { get; private set; } = Guid.NewGuid().ToString("N");
        public DateTime ExpiredAt { get; private set; } = DateTime.Now.AddDays(expiresInDays);
        public InvitationStatus Status { get; private set; } = InvitationStatus.Pending;
    }
}
