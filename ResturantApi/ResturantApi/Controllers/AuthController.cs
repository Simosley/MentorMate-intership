using Microsoft.AspNetCore.Mvc;
using ResturantApi.Business.Services;
using ResturantApi.Domain.Models;
namespace ResturantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("authorize")]
        public async Task<ActionResult> AuthorizeAsync(AuthenticateRequestModel request)
        {
            var token = await _authService.AuthorizeAsync(request);
            if (token != null)
            {
                return Ok(token);              
            }
            else
            {
                return Unauthorized("email not found");
            }      
        }
    }
}
