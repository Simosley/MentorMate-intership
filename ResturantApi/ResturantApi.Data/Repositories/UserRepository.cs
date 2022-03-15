using Microsoft.EntityFrameworkCore;
using ResturantApi.Domain.Entities;

namespace ResturantApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ResturantApiContext _context;

        public UserRepository(ResturantApiContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var deleteUserByIdAsync = await _context.Users.FindAsync(id);
            if (deleteUserByIdAsync == null)
            {
                return null;
            }
            _context.Users.Remove(deleteUserByIdAsync);
            await _context.SaveChangesAsync();
            return deleteUserByIdAsync;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var getAllUsersAsync = await _context.Users.ToListAsync();
            return getAllUsersAsync;
        }

        public async Task<List<User>> GetAllUsersAsyncPaginatedAsync(int page)
        {
            var pageSize = 20;
            var allUsersAsync = await _context.Users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return allUsersAsync;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var getUserByEmailAsync = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
            return getUserByEmailAsync;
        }
      
        public async Task<User> GetUserByIdAsync(int id)
        {
            var getUserByIdAsync = await _context.Users.FindAsync(id);
            return getUserByIdAsync;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
