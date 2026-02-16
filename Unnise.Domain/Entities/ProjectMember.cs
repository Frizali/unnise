namespace Unnise.Domain.Entities
{
    public class ProjectMember : BaseEntity
    {
        public Guid ProjectID { get; private set; }
        public Guid UserID { get; private set; }
        public string Role { get; set; } = null!;
        public DateTime JoinedAt { get; set; }

        public ProjectMember(Guid id, Guid projectId, Guid userId, string role) : base(id)
        {
            ProjectID = projectId;
            UserID = userId;
            Role = role;
        }

        public ProjectMember() : base(Guid.NewGuid()){}
    }
}
