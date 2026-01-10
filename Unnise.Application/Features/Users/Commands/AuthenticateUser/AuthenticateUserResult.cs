namespace Unnise.Application.Features.Users.Commands.AuthenticateUser
{
    public record AuthenticateUserResult(string AccessToken, string RefreshToken)
    {
    }
}
