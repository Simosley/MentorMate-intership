using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResturantApi.Business.Services;
using ResturantApi.Domain.Entities;
using ResturantApi.Domain.Models;

namespace ResturantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet,Authorize(Roles = "Admin")]
        [Route("{page}")]
        public async Task<ActionResult> GetAllUsersAsyncPaginatedAsync(int page)
        {
            var allUsersAsync = await _userService.GetAllUsersAsyncPaginatedAsync(page);
            if (allUsersAsync == null)
            {
                return BadRequest(Enumerable.Empty<User>());
            }

            return Ok(allUsersAsync);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddUserAsync(UserRequestModel userRequestModel)
        {
            var addUserAsync = await _userService.AddUserAsync(userRequestModel);
            if (addUserAsync == null)
            {
                return BadRequest("This email is in use");
            }
            return Ok("User created successfully");
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateUserAsync(int id, UserRequestModel userRequestModel)
        {
            var updateItemAsync = await _userService.UpdateUserAsync(id, userRequestModel);
            if (updateItemAsync == null)
            {
                return BadRequest("Error");
            }
            else
            {
                return Ok("User Updated Successfully");
            }
        }
        
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            var deleteUserAsync = await _userService.DeleteUserAsync(id);
            if (deleteUserAsync == null)
            {
                return BadRequest("no such user");
            }
            else
            {
                return Ok("user deleted");
            }
        }

        [HttpPut("editProfile"),Authorize(Roles ="Admin,Waiter")]
        public async Task<ActionResult> UpdateUserAsyncProfile(int id,UserEditProfileModel userEditProfileModel)
        {
            var userAuthenticated = User.Identity.Name;
            var roleAuthenticated = User.Claims.Where(x => x.Value == "Admin" || x.Value == "Waiter").Select(x => x.Value).FirstOrDefault();
            var updateUserProfileAsync = await _userService.UpdateProfileUser(id, userEditProfileModel,userAuthenticated,roleAuthenticated);
            if (updateUserProfileAsync == null)
            {
                return BadRequest("You cant edit that user");
            }
            else
            {
                return Ok(updateUserProfileAsync);
            }
        }
    }
}
