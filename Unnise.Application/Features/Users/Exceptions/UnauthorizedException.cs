using Unnise.Application.Common.Exceptions;

namespace Unnise.Application.Features.Users.Exceptions
{
    public class UnauthorizedException(string message) : AppException(message)
    {
    }
}
