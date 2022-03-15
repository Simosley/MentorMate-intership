using Microsoft.EntityFrameworkCore;
using ResturantApi.Domain.Entities;


namespace ResturantApi.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ResturantApiContext _context;
        public ProductRepository(ResturantApiContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProductAsync(int id, Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllProductsPaginatedAsync(int page, int pageSize)
        {
            var getAllProductsPaginated = await _context.Products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return getAllProductsPaginated;
        }

        public async Task<Product> GetProductByCategoryIdAsync(int id)
        {
            var getProductByCategoryId = await _context.Products.Where(x => x.CategoryId == id).FirstAsync();
            return getProductByCategoryId;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var getProductById = await _context.Products.FindAsync(id);
            return getProductById;
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
