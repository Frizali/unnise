using Microsoft.EntityFrameworkCore;
using Unnise.Application.Abstractions.Persistence;
using Unnise.Domain.Entities;
using Unnise.Infrastructure.Persistence;

namespace Unnise.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UnniseDbContext _context;
        public UserRepository(UnniseDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsEmailTakenAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> IsPhoneTakenAsync(string phone)
        {
            return await _context.Users.AnyAsync(u => u.Phone == phone); 
        }

        public async Task<bool> IsUsernameTakenAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }
    }
}
