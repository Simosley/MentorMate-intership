using ResturantApi.Domain.Entities;
using ResturantApi.Domain.Models;

namespace ResturantApi.Business.Services
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> AddUserAsync(UserRequestModel userRequestModel);
        Task<User> DeleteUserAsync(int id);
        Task<User> UpdateUserAsync(int id, UserRequestModel userRequestModel);
        Task<User> UpdateProfileUser(int id, UserEditProfileModel userEditProfileModel, string userAuthenticated, string roleAuthenticated);
        Task<UserResponseModel> GetAllUsersAsyncPaginatedAsync(int page);
    }
}
