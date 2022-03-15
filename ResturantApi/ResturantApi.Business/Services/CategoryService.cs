using ResturantApi.Data.Repositories;
using ResturantApi.Domain.Entities;
using ResturantApi.Domain.Models;

namespace ResturantApi.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public CategoryService(ICategoryRepository categoryRepository,IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<Category> AddCategoryAsync(CategoryRequestModel categoryRequestModel)
        {
            var category = new Category
            {
                CategoryName = categoryRequestModel.CategoryName,
                ParentCategoryId = categoryRequestModel.ParentCategoryId == 0 ? null : categoryRequestModel.ParentCategoryId
            };
            return await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task<Category> DeleteCategoryAsync(int id)
        {
            var allCategories = await _categoryRepository.GetAllCategoriesAsync();
            var categoryById = allCategories.Where(x => x.CategoryId == id && x.ParentCategoryId == null).ToList();
            var children = categoryById.SelectMany(x => x.Children).Where(x => x.ParentCategoryId != null).ToList();
            if (children.Count() != 0) return null;
            else
            {
                var targetCategory = await _categoryRepository.GetCategoryByIdAsync(id);
                if (targetCategory == null) return null;
                var productCheckId = await _productRepository.GetProductByCategoryIdAsync(id);
                if (productCheckId != null) return null;

                else return await _categoryRepository.DeleteCategoryAsync(targetCategory);
            }
        }

        public async Task<List<CategoryResponseModel>> GetAllCategoriesAsync()
        {
            var getAllCategories = await _categoryRepository.GetAllCategoriesAsync();
            var getParentCategory = getAllCategories.OrderBy(x => x.CategoryName).Where(x => x.ParentCategoryId == null).ToList();

            var response = getParentCategory
                  .Select(p => new CategoryResponseModel
                  {
                      Id = p.CategoryId,
                      Name = p.CategoryName,
                      SubCategories = p.Children.OrderBy(x => x.CategoryName).Select(x => x.CategoryName).ToList()
                  }).ToList();

            return response;
        }

        public async Task<Category> UpdateCategoryAsync(int id, CategoryRequestModel categoryRequestModel)
        {
            var targetCategory = await _categoryRepository.GetCategoryByIdAsync(id);
            if (targetCategory == null) return null;

            targetCategory.CategoryName = categoryRequestModel.CategoryName;
            targetCategory.ParentCategoryId = categoryRequestModel.ParentCategoryId == 0 ? null : categoryRequestModel.ParentCategoryId;

            return await _categoryRepository.UpdateCategoryAsync(targetCategory);
        }
    }
}
