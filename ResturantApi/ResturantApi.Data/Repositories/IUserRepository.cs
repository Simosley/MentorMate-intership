using ResturantApi.Domain.Entities;

namespace ResturantApi.Data.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsyncPaginatedAsync(int page);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User user);
        Task<User> DeleteUserAsync(int id);
        Task<User> UpdateUserAsync(User user);      
    }
}
