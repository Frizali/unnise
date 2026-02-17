using MediatR;

namespace Unnise.Application.Features.ProjectMembers.Commands.InviteProjectMember
{
    public record InviteProjectMemberCommand(Guid ProjectId, Guid UserId, string Role) : IRequest
    {
    }
}
