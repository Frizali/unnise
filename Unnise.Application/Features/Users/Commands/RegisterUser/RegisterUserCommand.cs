using MediatR;

namespace Unnise.Application.Features.Users.Commands.RegisterUser
{
    public record RegisterUserCommand(
        string Username,
        string GlobalName,
        string Email,
        string Password,
        string ConfirmPassword
    ) : IRequest<Guid>;
}
