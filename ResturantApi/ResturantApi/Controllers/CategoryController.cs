using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResturantApi.Business.Services;
using ResturantApi.Domain.Entities;
using ResturantApi.Domain.Models;

namespace ResturantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAllCategoriesAsync()
        {
            var getAllCategories = await _categoryService.GetAllCategoriesAsync();
            if (getAllCategories == null)
            {
                return BadRequest(Enumerable.Empty<Category>());
            }
            else
            {
                return Ok(getAllCategories);
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddCategoryAsync(CategoryRequestModel categoryRequestModel)
        {
            var addCategory = await _categoryService.AddCategoryAsync(categoryRequestModel);
            if (addCategory == null)
            {
                return BadRequest("Couldn't create category");
            }
            else
            {
                return Ok(categoryRequestModel);
            }
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateCategoryAsync(int id, CategoryRequestModel categoryRequestModel)
        {
            var updateCategory = await _categoryService.UpdateCategoryAsync(id, categoryRequestModel);
            if (updateCategory == null)
            {
                return BadRequest("Couldnt update category");
            }
            else
            {
                return Ok(categoryRequestModel);
            }
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteCategoryAsync(int id)
        {
            var deleteCategory = await _categoryService.DeleteCategoryAsync(id);
            if (deleteCategory == null)
            {
                return BadRequest("Cannot delete category");
            }
            else
            {
                return Ok("Category deleted successfully");
            }
        }
    }
}
