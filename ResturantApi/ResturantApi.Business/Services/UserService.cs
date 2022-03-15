using ResturantApi.Data.Repositories;
using ResturantApi.Domain.Entities;
using ResturantApi.Domain.Models;

namespace ResturantApi.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> AddUserAsync(UserRequestModel userRequestModel)
        {
            var foundUserAsync = await _userRepository.GetUserByEmailAsync(userRequestModel.Email);
            var passwordHashed = BCrypt.Net.BCrypt.HashPassword(userRequestModel.Password);
            var user = new User
            {
                Role = userRequestModel.Role,
                Name = userRequestModel.Name,
                Email = userRequestModel.Email,
                Password = passwordHashed,
                ImageUrl = ""
            };
            if (foundUserAsync == null)
            {

                return await _userRepository.AddUserAsync(user);
            }
            else
            {
                return null;
            }
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var deleteUser = await _userRepository.DeleteUserAsync(id);
            if (deleteUser == null) return null;
            
            else return deleteUser;
        }

        public async Task<UserResponseModel> GetAllUsersAsyncPaginatedAsync(int page)
        {
            if (page <= 0) return null;

            var allUsersAsyncPaginatedAsync = await _userRepository.GetAllUsersAsyncPaginatedAsync(page);
            if (allUsersAsyncPaginatedAsync == null) return null;
            var totalPages = Math.Ceiling((float)allUsersAsyncPaginatedAsync.Count()/page);
            var nameAndEmail = allUsersAsyncPaginatedAsync.Select(p => new UserResponseModelProps {Name=p.Name,Email=p.Email}).ToList();
            var response = new UserResponseModel
            {
                TotalUsers = allUsersAsyncPaginatedAsync.Count(),
                CurrentPage = page,
                TotalPages = (int)totalPages,
                Users = nameAndEmail
            };

            return response;
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return user;
        }

        public async Task<User> UpdateProfileUser(int id, UserEditProfileModel userEditProfileModel, string userAuthenticated, string roleAuthenticated)
        {
            var targetUser = await _userRepository.GetUserByIdAsync(id);
            if (targetUser == null) return null;


            if (roleAuthenticated == "Waiter" && userAuthenticated == targetUser.Name)
            {
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(userEditProfileModel.Password);
                targetUser.Name = userEditProfileModel.Name;
                targetUser.Password = passwordHash;
                targetUser.ImageUrl = userEditProfileModel.ImageUrl;
            }
            if (roleAuthenticated == "Admin")
            {
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(userEditProfileModel.Password);
                targetUser.Name = userEditProfileModel.Name;
                targetUser.Password = passwordHash;
                targetUser.ImageUrl = userEditProfileModel.ImageUrl;
            }
            else if (userAuthenticated != targetUser.Name)
            {
                return null;
            }

            return await _userRepository.UpdateUserAsync(targetUser);

        }

        public async Task<User> UpdateUserAsync(int id, UserRequestModel userRequestModel)
        {
            var targetUser = await _userRepository.GetUserByIdAsync(id);
            if (targetUser == null)
            {
                return null;
            }
            var checkUpdatedUserEmail = await _userRepository.GetUserByEmailAsync(userRequestModel.Email);
            if (checkUpdatedUserEmail == null)
            {
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(userRequestModel.Password);
                targetUser.Role = userRequestModel.Role;
                targetUser.Name = userRequestModel.Name;
                targetUser.Email = userRequestModel.Email;
                if (targetUser.Password == string.Empty)
                {
                    targetUser.Password = targetUser.Password;
                }
                else
                {
                    targetUser.Password = passwordHash;
                }
                return await _userRepository.UpdateUserAsync(targetUser);
            }
            else
            {
                return null;
            }
        }
    }
}
