using Commention.Domain.Interfaces;
using Commention.Domain.Models.Entities;
using Commention.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Commention.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(long userId)
        {
            var model = await GetUserByIdAsync(userId);
            _context.Users.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(long userId)
        {
            var model = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (model == null)
            {
                throw new Exception("کاربر پیدا نشد.");
            }
            return model;
        }

        public async Task<User> GetUserByUserNameAndPassword(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new Exception("نام کاربری یا رمز عبور اشتباه است.");
            }
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
