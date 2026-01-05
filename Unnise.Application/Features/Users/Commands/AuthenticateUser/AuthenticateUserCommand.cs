using MediatR;

namespace Unnise.Application.Features.Users.Commands.AuthenticateUser
{
    public record AuthenticateUserCommand(string Identity, string Password) : IRequest<string>;
}
