using MediatR;
using Unnise.Application.Abstractions.Persistence;
using Unnise.Application.Abstractions.Security;
using Unnise.Application.Features.Users.Exceptions;
using Unnise.Domain.Entities;

namespace Unnise.Application.Features.Users.Commands.GenerateRefreshToken
{
    public class GenerateRefreshTokenHandler(ICurrentUser currentUser, IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository, ITokenGenerator tokenGenerator) : IRequestHandler<GenerateRefreshTokenCommand, GenerateRefreshTokenResult>
    {
        private readonly ICurrentUser _currentUser = currentUser;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;
        private readonly ITokenGenerator _tokenGenerator = tokenGenerator;

        public async Task<GenerateRefreshTokenResult> Handle(GenerateRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var refreshToken = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken);

            if (refreshToken is null || !refreshToken.IsActive)
                throw new UnauthorizedException("Invalid refresh token.");

            var user = await _userRepository.GetByIdAsync(_currentUser.Id)
                       ?? throw new UnauthorizedException("User not found.");

            var accessToken = _tokenGenerator.GenerateAccessToken(user);
            var newRefreshTokenValue = _tokenGenerator.GenerateRefreshToken();

            refreshToken.RevokeToken();
            refreshToken.ReplaceToken(newRefreshTokenValue);

            await _refreshTokenRepository.UpdateAsync(refreshToken);

            var newRefreshToken = new RefreshToken(
                id: Guid.NewGuid(),
                userId: _currentUser.Id,
                token: newRefreshTokenValue,
                createdAt: DateTime.UtcNow,
                expiresAt: DateTime.UtcNow.AddDays(7)
            );

            await _refreshTokenRepository.AddAsync(newRefreshToken);

            return new GenerateRefreshTokenResult(accessToken, newRefreshTokenValue);
        }
    }

}
