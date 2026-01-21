using MediatR;

namespace Unnise.Application.Features.ProjectMembers.Commands.InviteProjectMember
{
    public record InviteProjectMemberCommand(Guid ProjectId, string identity, string Role) : IRequest
    {
    }
}
