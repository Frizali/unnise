using FluentAssertions;
using Moq;
using Unnise.Application.Abstractions.Persistence;
using Unnise.Application.Abstractions.Security;
using Unnise.Application.Features.Users.Commands.RegisterUser;
using Unnise.Domain.Entities;

namespace Unnise.Application.Test.Users;

public class RegisterUserHandlerTest
{
    private readonly Mock<IUserRepository> _userRepoMock = new();
    private readonly Mock<IPasswordHasher> _hasherMock = new();

    [Fact]
    public void Handle_Should_Register_User_When_Data_Is_Valid()
    {
        _userRepoMock.Setup(x => x.IsUsernameTakenAsync(It.IsAny<string>())).ReturnsAsync(false);
        _userRepoMock.Setup(x => x.IsEmailTakenAsync(It.IsAny<string>())).ReturnsAsync(false);
        _hasherMock.Setup(x => x.Hash(It.IsAny<string>())).Returns("password");

        var handler = new RegisterUserHandler(_userRepoMock.Object, _hasherMock.Object);
        var command = new RegisterUserCommand("Frizali", "frizali", "frizali@gmail.com", "123456");
        var result = handler.Handle(command, default);

        result.Should().NotBeNull();
        _userRepoMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
    }
}
