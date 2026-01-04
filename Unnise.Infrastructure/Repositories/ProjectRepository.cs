using Microsoft.EntityFrameworkCore;
using System.Threading;
using Unnise.Application.Abstractions.Persistence;
using Unnise.Infrastructure.Persistence;

namespace Unnise.Infrastructure.Repositories
{
    public class ProjectRepository(UnniseDbContext context) : IProjectRepository
    {
        readonly UnniseDbContext _context = context;

        public async Task<bool> IsNameUniqueAsync(string name)
        {
            return !await _context.Projects.AnyAsync(p => EF.Functions.Like(p.Name, name));
        }
    }
}
