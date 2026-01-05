using Unnise.Domain.Entities;

namespace Unnise.Application.Test.Common.Factories
{
    public static class UserFactory
    {
        public static User Create()
        {
            return new User(Guid.NewGuid(), "username", "globalName", "email@gmail.com", "hashed-password");
        }
    }
}
