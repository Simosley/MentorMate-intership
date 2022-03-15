using ResturantApi.Data.Repositories;
using ResturantApi.Domain.Entities;
using ResturantApi.Domain.Models;

namespace ResturantApi.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Product> AddProductAsync(ProductRequestModel productRequestModel)
        {
            var checkCategoryId = await _categoryRepository.GetCategoryByIdAsync(productRequestModel.CategoryId);
            if (checkCategoryId == null) return null;
            var product = new Product
            {
                ProductName = productRequestModel.ProductName,
                Description = productRequestModel.Description,
                Price = productRequestModel.Price,
                CategoryId = productRequestModel.CategoryId
            };
            var addProduct = await _productRepository.AddProductAsync(product);

            return addProduct;
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            var targetProduct = await _productRepository.GetProductByIdAsync(id);
            if (targetProduct == null) return null;

            return await _productRepository.DeleteProductAsync(id, targetProduct);
        }

        public async Task<ProductResponseModel> GetAllProductsPaginatedAsync(string? product, int? categoryId, int page, int pageSize, string? sortBy, string? sortDirection)
        {
            var allProducts = await _productRepository.GetAllProductsPaginatedAsync(page, pageSize);
            var categories = await _categoryRepository.GetAllCategoriesAsync();

            var items = new List<ProductResponseModelItems>();
            if (product != null)
            {
                items = allProducts.
                    Where(x => x.ProductName == product).ToList().
                    Select(x => new ProductResponseModelItems
                    {
                        ProductId = x.ProductId,
                        ProductName = x.ProductName,
                        Description = x.Description,
                        Price = x.Price,
                        CategoryId = (int)x.CategoryId,
                        Category = x.Category.CategoryName
                    }).ToList();
            }
            if (categoryId != null)
            {
                items = allProducts.
                    Where(x => x.Category.CategoryId == categoryId).ToList().
                    Select(x => new ProductResponseModelItems
                    {
                        ProductId = x.ProductId,
                        ProductName = x.ProductName,
                        Description = x.Description,
                        Price = x.Price,
                        CategoryId = (int)x.CategoryId,
                        Category = x.Category.CategoryName
                    }).ToList();
            }
            if (items.Count() == 0)
            {
                items = allProducts.
                    Select(x => new ProductResponseModelItems
                    {
                        ProductId = x.ProductId,
                        ProductName = x.ProductName,
                        Description = x.Description,
                        Price = x.Price,
                        CategoryId = (int)x.CategoryId,
                        Category = x.Category.CategoryName
                    }).ToList();
            }
            if (sortBy == "Name")
            {
                items = items.OrderBy(x => x.ProductName).ToList();
                if (sortDirection == "Desc")
                {
                    items = items.OrderByDescending(x => x.ProductName).ToList();
                }
            }
            if (sortBy == "Category")
            {
                items = items.OrderBy(x => x.Category).ToList();
                if (sortDirection == "Desc")
                {
                    items = items.OrderByDescending(x => x.Category).ToList();
                }
            }
            var response = new ProductResponseModel
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalProducts = items.Count(),
                Items = items
            };

            return response;
        }

        public async Task<Product> UpdateProductAsync(int id, ProductRequestModel productRequestModel)
        {
            var targetProduct = await _productRepository.GetProductByIdAsync(id);
            if (targetProduct == null) return null;
            var targetCategoryId = await _productRepository.GetProductByIdAsync(productRequestModel.CategoryId);
            if (targetCategoryId == null) return null;

            targetProduct.ProductName = productRequestModel.ProductName;
            targetProduct.Description = productRequestModel.Description;
            targetProduct.Price = productRequestModel.Price;
            targetProduct.CategoryId = productRequestModel.CategoryId;

            return await _productRepository.UpdateProductAsync(id, targetProduct);
        }
    }
}
