using ResturantApi.Domain.Entities;

namespace ResturantApi.Data.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsPaginatedAsync(int page, int pageSize);
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(Product product);
        Task<Product> DeleteProductAsync(int id, Product product);
        Task<Product> UpdateProductAsync(int id, Product product);
        Task<Product> GetProductByCategoryIdAsync(int id);
    }
}
