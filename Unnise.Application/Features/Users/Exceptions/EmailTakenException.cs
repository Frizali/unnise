using Unnise.Application.Common.Exceptions;

namespace Unnise.Application.Features.Users.Exceptions
{
    public class EmailTakenException : ConflictException
    {
        public EmailTakenException() : base("Email is already registered.")
        {
        }
    }
}
