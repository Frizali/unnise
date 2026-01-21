using Unnise.Domain.Entities;

namespace Unnise.Application.Abstractions.Persistence
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken refreshToken);
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task UpdateAsync(RefreshToken refreshToken);
    }
}
