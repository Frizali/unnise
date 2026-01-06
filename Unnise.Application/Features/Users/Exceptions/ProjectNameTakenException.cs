using Unnise.Application.Common.Exceptions;

namespace Unnise.Application.Features.Users.Exceptions
{
    public class ProjectNameTakenException(string name) : ConflictException($"Project name {name} already exists in this account")
    {
    }
}
