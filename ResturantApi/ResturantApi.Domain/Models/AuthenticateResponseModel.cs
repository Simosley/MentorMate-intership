using ResturantApi.Domain.Entities;

namespace ResturantApi.Domain.Models
{
    public class AuthenticateResponseModel
    {
        public string Token { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}
