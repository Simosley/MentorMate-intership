using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ResturantApi.Data.Repositories;
using ResturantApi.Domain.Entities;
using ResturantApi.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ResturantApi.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<AuthenticateResponseModel?> AuthorizeAsync(AuthenticateRequestModel authenticateRequestModel)
        {
            var foundUserAsync = await _userRepository.GetUserByEmailAsync(authenticateRequestModel.Email);
            if (foundUserAsync == null)
            {
                return null;
            }
            var isPasswordMatching = BCrypt.Net.BCrypt.Verify(authenticateRequestModel.Password, foundUserAsync.Password);
            if (foundUserAsync.Email == authenticateRequestModel.Email && isPasswordMatching)
            {
                var token = CreateToken(foundUserAsync);
                return new AuthenticateResponseModel
                {
                    Token = token,
                    Email = getJWTTokenClaim(token, foundUserAsync.Email),
                    Role = getJWTTokenClaim(token,foundUserAsync.Role.ToString())
                };
            }
            else
            {
                return null;
            }
        }

        private string CreateToken(User user)
        {          
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role.ToString()),
                new Claim(ClaimTypes.Name,user.Name)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string getJWTTokenClaim(string token, string claimName)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                var claimValue = securityToken.Claims.FirstOrDefault(e => e.Value == claimName).Value.ToString();
                return claimValue;
            }
            catch (Exception)
            {
                //TODO: Logger.Error
                return null;
            }
        }
    }
}
