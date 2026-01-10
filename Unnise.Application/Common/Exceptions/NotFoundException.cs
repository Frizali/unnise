namespace Unnise.Application.Common.Exceptions
{
    public class NotFoundException(string message) : AppException(message)
    {
    }
}
