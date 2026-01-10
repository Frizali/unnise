using MediatR;
using Unnise.Application.Abstractions.Persistence;
using Unnise.Application.Abstractions.Security;
using Unnise.Application.Features.Users.Exceptions;
using Unnise.Domain.Entities;

namespace Unnise.Application.Features.Users.Commands.AuthenticateUser
{
    public class AuthenticateUserHandler(IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository, IPasswordHasher passwordHasher, ITokenGenerator tokenGenerator) : IRequestHandler<AuthenticateUserCommand, AuthenticateUserResult>
    {
        readonly IUserRepository _userRepository = userRepository;
        readonly IRefreshTokenRepository _refreshTokenRespository = refreshTokenRepository;
        readonly IPasswordHasher _passwordHasher = passwordHasher;
        readonly ITokenGenerator _tokenGenerator = tokenGenerator;

        public async Task<AuthenticateUserResult> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdentityAsync(request.Identity) ?? throw new InvalidCredentialException();

            if (!_passwordHasher.Verify(request.Password, user.PasswordHash))
                throw new InvalidCredentialException();

            var accessToken = _tokenGenerator.GenerateAccessToken(user);
            var refreshToken = _tokenGenerator.GenerateRefreshToken();

            var refreshEntity = new RefreshToken(
                Guid.NewGuid(),
                user.Id,
                refreshToken,
                DateTime.Now,
                DateTime.Now.AddDays(7)
            );

            await _refreshTokenRespository.AddAsync(refreshEntity);

            return new AuthenticateUserResult(accessToken, refreshToken);
        }
    }
}
