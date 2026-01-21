using Microsoft.EntityFrameworkCore;
using System.Threading;
using Unnise.Application.Abstractions.Persistence;
using Unnise.Domain.Entities;
using Unnise.Infrastructure.Persistence;

namespace Unnise.Infrastructure.Repositories
{
    public class ProjectRepository(UnniseDbContext context) : IProjectRepository
    {
        private readonly UnniseDbContext _context = context;

        public async Task AddAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task<Project?> GetByIdAsync(Guid projectId)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId);
        }

        public async Task<bool> IsNameUniqueAsync(Guid ownerId, string name)
        {
            return !await _context.Projects.AnyAsync(p => p.OwnerId == ownerId && EF.Functions.Like(p.Name, name));
        }
    }
}
