namespace Unnise.Domain.Entities
{
    public class ProjectMember : BaseEntity
    {
        public Guid ProjectID { get; private set; }
        public Guid UserID { get; private set; }
        public string Role { get; private set; } = null!;
        public DateTime JoinedAt { get; private set; }

        public ProjectMember(Guid id, Guid projectId, Guid userId, string role, DateTime joinedAt) : base(id)
        {
            ProjectID = projectId;
            UserID = userId;
            Role = role;
            JoinedAt = joinedAt;
        }
        
        private ProjectMember() : base(Guid.Empty) { }
    }
}
