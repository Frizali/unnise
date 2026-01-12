using Unnise.Application.Abstractions.Persistence;
using Unnise.Domain.Entities;
using Unnise.Infrastructure.Persistence;

namespace Unnise.Infrastructure.Repositories
{
    public class ProjectMemberRepository(UnniseDbContext context) : IProjectMemberRepository
    {
        private readonly UnniseDbContext _context = context;

        public async Task AddAsync(ProjectMember projectMember)
        {
            _context.ProjectMembers.Add(projectMember);
            await _context.SaveChangesAsync();
        }
    }
}
