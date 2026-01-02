using Unnise.Application.Common.Exceptions;

namespace Unnise.Application.Features.Users.Exceptions
{
    public class EmailTakenException : ConflictException
    {
        public EmailTakenException() : base("The email you have provided is already associated with an account.")
        {
        }
    }
}
