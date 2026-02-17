using MediatR;
using Unnise.Application.Abstractions.Persistence;
using Unnise.Application.Common.Exceptions;
using Unnise.Domain.Entities;

namespace Unnise.Application.Features.ProjectMembers.Commands.InviteProjectMember
{
    public class InviteProjectMemberHandler(IProjectMemberRepository projectMemberRepository, IProjectInvitationRepository projectInvitationRepository) : IRequestHandler<InviteProjectMemberCommand>
    {
        private readonly IProjectMemberRepository _projectMemberRepository = projectMemberRepository;
        private readonly IProjectInvitationRepository _projectInvitationRepository = projectInvitationRepository;

        public async Task Handle(InviteProjectMemberCommand request, CancellationToken cancellationToken)
        {
            if (await _projectMemberRepository.IsMemberAlreadyJoined(request.ProjectId, request.UserId))
                throw new ArgumentException("Member already joined");

            var invitation = new ProjectInvitation(
                    Guid.NewGuid(),
                    request.ProjectId,
                    request.UserId,
                    request.Role,
                    7
                );

            await _projectInvitationRepository.AddAsync(invitation);
        }
    }
}
