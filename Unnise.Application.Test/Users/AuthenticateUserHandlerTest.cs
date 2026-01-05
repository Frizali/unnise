using FluentAssertions;
using Moq;
using Unnise.Application.Abstractions.Persistence;
using Unnise.Application.Abstractions.Security;
using Unnise.Application.Features.Users.Commands.AuthenticateUser;
using Unnise.Application.Features.Users.Exceptions;
using Unnise.Application.Test.Common.Factories;
using Unnise.Domain.Entities;

namespace Unnise.Application.Test.Users
{
    public class AuthenticateUserHandlerTest
    {
        private readonly Mock<IUserRepository> _userRepoMock = new();
        private readonly Mock<IPasswordHasher> _hasherMock = new();
        private readonly Mock<ITokenGenerator> _tokenMock = new();

        private AuthenticateUserHandler CreateHandler() => new(_userRepoMock.Object, _hasherMock.Object, _tokenMock.Object);

        [Fact]
        public async Task Handle_ShouldThrow_WhenUserNotFound()
        {
            var command = new AuthenticateUserCommand("email@gmail.com", "hashed-password");

            _userRepoMock.Setup(x => x.GetByIdentityAsync(It.IsAny<string>())).ReturnsAsync((User?)null);

            var handler = CreateHandler();

            await Assert.ThrowsAsync<InvalidCredentialException>(() => handler.Handle(command, default));
        }

        [Fact]
        public void Handle_Should_Authenticate_User_When_Data_Is_Valid()
        {
            var user = UserFactory.Create();
            var command = new AuthenticateUserCommand("email@gmail.com", "hashed-password");
            var expectedToken = "jwt-token";

            _userRepoMock.Setup(x => x.GetByIdentityAsync(It.IsAny<string>())).ReturnsAsync(user);
            _hasherMock.Setup(x => x.Verify(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            _tokenMock.Setup(x => x.GenerateToken(user)).Returns(expectedToken);

            var handler = CreateHandler();
            var result = handler.Handle(command, default);

            result.Should().Be(expectedToken);
        }
    }
}
