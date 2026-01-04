using MediatR;
using Unnise.Application.Abstractions.Persistence;

namespace Unnise.Application.Features.Projects.Queries.IsProjectNameAvailable
{
    public class IsProjectNameAvailableHandler(IProjectRepository projectRepository) : IRequestHandler<IsProjectNameAvailableQuery, IsProjectNameAvailableResult>
    {
        readonly IProjectRepository _projectRepository = projectRepository;

        public async Task<IsProjectNameAvailableResult> Handle(IsProjectNameAvailableQuery query, CancellationToken cancellationToken)
        {
            var isUnique = await _projectRepository.IsNameUniqueAsync(query.Name);

            if (isUnique)
            {
                return new IsProjectNameAvailableResult(true, null);
            }

            return new IsProjectNameAvailableResult(false, "Project name already exists in this account");
        }
    }
}
