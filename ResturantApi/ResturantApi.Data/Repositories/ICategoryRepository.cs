using ResturantApi.Domain.Entities;

namespace ResturantApi.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> DeleteCategoryAsync(Category category);
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> UpdateCategoryAsync(Category category);
    }
}
