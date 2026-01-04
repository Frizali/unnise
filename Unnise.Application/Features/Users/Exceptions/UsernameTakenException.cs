using Unnise.Application.Common.Exceptions;

namespace Unnise.Application.Features.Users.Exceptions
{
    public class UsernameTakenException(string username) : ConflictException($"Username '{username}' already taken.")
    {
    }
}
