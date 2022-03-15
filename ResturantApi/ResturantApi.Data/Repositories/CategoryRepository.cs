using Microsoft.EntityFrameworkCore;
using ResturantApi.Domain.Entities;

namespace ResturantApi.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ResturantApiContext _context;
        public CategoryRepository(ResturantApiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var allCategories = await _context.Categories.Include(x => x.Children).Include(x => x.ParentCategory).ToListAsync();
            return allCategories;
        }
        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategoryAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var getCategoryByid = await _context.Categories.FindAsync(id);
            return getCategoryByid;
        }
    }
}
