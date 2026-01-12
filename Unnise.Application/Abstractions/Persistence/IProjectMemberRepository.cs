using Unnise.Domain.Entities;

namespace Unnise.Application.Abstractions.Persistence
{
    public interface IProjectMemberRepository
    {
        Task AddAsync(ProjectMember projectMember);
    }
}
