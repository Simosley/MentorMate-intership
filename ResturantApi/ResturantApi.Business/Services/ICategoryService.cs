using ResturantApi.Domain.Entities;
using ResturantApi.Domain.Models;

namespace ResturantApi.Business.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseModel>> GetAllCategoriesAsync();
        Task<Category> AddCategoryAsync(CategoryRequestModel categoryRequestModel);
        Task<Category> DeleteCategoryAsync(int id);
        Task<Category> UpdateCategoryAsync(int id, CategoryRequestModel categoryRequestModel);
    }
}
