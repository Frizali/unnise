using MediatR;
using Unnise.Application.Abstractions.Persistence;
using Unnise.Application.Common.Exceptions;
using Unnise.Domain.Entities;

namespace Unnise.Application.Features.ProjectMembers.Commands.InviteProjectMember
{
    public class InviteProjectMemberHandler(IProjectRepository projectRepository, ) : IRequestHandler<InviteProjectMemberCommand>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task Handle(InviteProjectMemberCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.ProjectId) ?? throw new NotFoundException("Project not found");

            var invitation = new ProjectInvitation(
                    Guid.NewGuid(),
                    request.ProjectId,
                    request.identity,
                    request.Role,
                    7
                );

            await _projectRepository.AddAsync(invitation);
        }
    }
}
