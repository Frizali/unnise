using Unnise.Domain.Entities;

namespace Unnise.Application.Abstractions.Security
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}
