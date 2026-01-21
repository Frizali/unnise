using MediatR;
using Unnise.Application.Abstractions.Persistence;
using Unnise.Application.Abstractions.Security;

namespace Unnise.Application.Features.Projects.Queries.IsProjectNameAvailable
{
    public class IsProjectNameAvailableHandler(ICurrentUser currentUser, IProjectRepository projectRepository) : IRequestHandler<IsProjectNameAvailableQuery, IsProjectNameAvailableResult>
    {
        readonly IProjectRepository _projectRepository = projectRepository;
        readonly ICurrentUser _currentUser = currentUser;
        public async Task<IsProjectNameAvailableResult> Handle(IsProjectNameAvailableQuery query, CancellationToken cancellationToken)
        {
            var isUnique = await _projectRepository.IsNameUniqueAsync(_currentUser.Id, query.Name);

            if (isUnique)
                return new IsProjectNameAvailableResult(true, null);

            return new IsProjectNameAvailableResult(false, "Project name already exists in this account");
        }
    }
}
