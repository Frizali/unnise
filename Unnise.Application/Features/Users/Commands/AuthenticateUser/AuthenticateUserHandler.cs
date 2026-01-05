using MediatR;
using Unnise.Application.Abstractions.Persistence;
using Unnise.Application.Abstractions.Security;
using Unnise.Application.Features.Users.Exceptions;

namespace Unnise.Application.Features.Users.Commands.AuthenticateUser
{
    public class AuthenticateUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenGenerator tokenGenerator) : IRequestHandler<AuthenticateUserCommand, string>
    {
        readonly IUserRepository _userRepository = userRepository;
        readonly IPasswordHasher _passwordHasher = passwordHasher;
        readonly ITokenGenerator _tokenGenerator = tokenGenerator;

        public async Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdentityAsync(request.Identity) ?? throw new InvalidCredentialException();

            if (!_passwordHasher.Verify(request.Password, user.PasswordHash))
                throw new InvalidCredentialException();

            return _tokenGenerator.GenerateToken(user);
        }
    }
}
