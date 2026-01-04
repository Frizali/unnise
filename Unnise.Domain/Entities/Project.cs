using Unnise.Domain.Enums;
using Unnise.Domain.Exceptions;

namespace Unnise.Domain.Entities
{
    public class Project : BaseEntity
    {
        public Guid OwnerId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public ProjectVisibility Visibility { get; private set; }


        public Project(
            Guid id,
            Guid ownerId,
            string name,
            string? description,
            ProjectVisibility visibility)
            : base(id)
        {
            if (ownerId == Guid.Empty)
                throw new DomainException("Owner is required.");

            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Project name is required.");

            OwnerId = ownerId;
            Name = name;
            Description = description;
            Visibility = visibility;

            MarkCreated();
        }

        public void ChangeVisibility(ProjectVisibility visibility)
        {
            if (Visibility == visibility)
                return;

            Visibility = visibility;

            MarkUpdated();
        }
    }

}
