using ResturantApi.Domain.Entities;
using ResturantApi.Domain.Models;

namespace ResturantApi.Business.Services
{
    public interface IProductService
    {
        Task<ProductResponseModel> GetAllProductsPaginatedAsync(string? product, int? categoryId, int page, int pageSize, string? sortBy, string? sortDirection);
        Task<Product> AddProductAsync(ProductRequestModel productRequestModel);
        Task<Product> DeleteProductAsync(int id);
        Task<Product> UpdateProductAsync(int id, ProductRequestModel productRequestModel);
    }
}
