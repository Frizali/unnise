using MediatR;
using Unnise.Application.Abstractions.Persistence;
using Unnise.Application.Abstractions.Security;
using Unnise.Application.Features.Users.Exceptions;
using Unnise.Domain.Entities;

namespace Unnise.Application.Features.Projects.Commands.CreateProject
{
    public class CreateProjectHandler(ICurrentUser currentUser, IProjectRepository projectRepository) : IRequestHandler<CreateProjectCommand>
    {
        readonly ICurrentUser _currentUser = currentUser;
        readonly IProjectRepository _projectRepository = projectRepository;

        public async Task Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var isUnique = await _projectRepository.IsNameUniqueAsync(_currentUser.Id, request.Name);

            if (!isUnique) throw new ProjectNameTakenException(request.Name);

            var project = new Project(
                    Guid.NewGuid(),
                    _currentUser.Id,
                    request.Name,
                    request.Description,
                    request.Visibility
                );

            await _projectRepository.AddAsync(project);
        }
    }
}
