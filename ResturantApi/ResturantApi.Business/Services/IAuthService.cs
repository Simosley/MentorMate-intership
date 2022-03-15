using ResturantApi.Domain.Models;

namespace ResturantApi.Business.Services
{
    public interface IAuthService
    {
        Task<AuthenticateResponseModel?> AuthorizeAsync(AuthenticateRequestModel authenticateRequestModel);
    }
}
