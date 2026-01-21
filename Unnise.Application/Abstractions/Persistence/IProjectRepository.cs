using Unnise.Domain.Entities;

namespace Unnise.Application.Abstractions.Persistence
{
    public interface IProjectRepository
    {
        Task<Project?> GetByIdAsync(Guid projectId);
        Task<bool> IsNameUniqueAsync(Guid ownerId, string name);

        Task AddAsync(Project project);
    }
}
