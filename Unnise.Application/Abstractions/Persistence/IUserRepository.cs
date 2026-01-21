using Unnise.Domain.Entities;

namespace Unnise.Application.Abstractions.Persistence
{
    public interface IUserRepository
    {
        Task AddAsync(User user);

        Task<bool> IsEmailTakenAsync(string email);
        Task<bool> IsPhoneTakenAsync(string phone);
        Task<bool> IsUsernameTakenAsync(string username);
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByIdentityAsync(string identity);
    }
}