using Unnise.Application.Abstractions.Persistence;
using Unnise.Domain.Entities;
using Unnise.Infrastructure.Persistence;

namespace Unnise.Infrastructure.Repositories
{
    public class ProjectInvitationRepository(UnniseDbContext context) : IProjectInvitationRepository
    {
        private readonly UnniseDbContext _context = context;

        public async Task AddAsync(ProjectInvitation projectInvitation)
        {
            _context.ProjectInvitations.Add(projectInvitation);
            await _context.SaveChangesAsync();
        }
    }
}
