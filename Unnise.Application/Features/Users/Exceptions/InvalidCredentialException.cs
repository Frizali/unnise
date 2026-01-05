using Unnise.Application.Common.Exceptions;

namespace Unnise.Application.Features.Users.Exceptions
{
    public class InvalidCredentialException() : AppException("Incorrect username or password.")
    {
    }
}
