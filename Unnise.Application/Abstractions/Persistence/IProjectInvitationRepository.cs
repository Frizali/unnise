using Unnise.Domain.Entities;

namespace Unnise.Application.Abstractions.Persistence
{
    public interface IProjectInvitationRepository
    {
        Task AddAsync(ProjectInvitation projectInvitation);
    }
}
