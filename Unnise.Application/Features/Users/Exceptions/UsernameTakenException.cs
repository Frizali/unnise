using Unnise.Application.Common.Exceptions;

namespace Unnise.Application.Features.Users.Exceptions
{
    public class UsernameTakenException : ConflictException
    {
        public UsernameTakenException(string username) : base($"Username '{username}' already taken.")
        {
        }
    }
}
