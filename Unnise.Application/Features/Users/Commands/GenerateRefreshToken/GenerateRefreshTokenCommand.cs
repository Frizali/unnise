using MediatR;

namespace Unnise.Application.Features.Users.Commands.GenerateRefreshToken
{
    public record GenerateRefreshTokenCommand(string RefreshToken) : IRequest<GenerateRefreshTokenResult>
    {
    }
}
