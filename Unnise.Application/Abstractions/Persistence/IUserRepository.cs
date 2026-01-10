using Unnise.Domain.Entities;

namespace Unnise.Application.Abstractions.Persistence
{
    public interface IUserRepository
    {
        Task<bool> IsUsernameTakenAsync(string username);
        Task<bool> IsEmailTakenAsync(string email);
        Task<bool> IsPhoneTakenAsync(string phone);
        Task<User?> GetByIdentityAsync(string identity);
        Task<User?> GetByIdAsync(Guid id);

        Task AddAsync(User user);
    }
}
