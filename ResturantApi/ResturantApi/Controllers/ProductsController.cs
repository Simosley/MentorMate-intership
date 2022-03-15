using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResturantApi.Business.Services;
using ResturantApi.Domain.Entities;
using ResturantApi.Domain.Models;

namespace ResturantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAllProductsPaginatedAsync(string? product, int? categoryId , int page = 1, int pageSize = 20,string? sortBy ="Name or Category", string? sortDirection="Desc or Asc")
        {
            var allProducts = await _productService.GetAllProductsPaginatedAsync(product, categoryId, page, pageSize, sortBy, sortDirection);
            if(allProducts == null)
            {
                return BadRequest(Enumerable.Empty<Product>());
            }
            else
            {
                return Ok(allProducts);
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddProductAsync(ProductRequestModel productRequestModel)
        {
            var addProduct = await _productService.AddProductAsync(productRequestModel);
            if (addProduct == null)
            {
                return BadRequest("Couldnt create product or couldnt find categoryId");
            }
            else
            {
                return Ok(productRequestModel);
            }
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateProductAsync(int id,ProductRequestModel productRequestModel)
        {
            var updateProduct = await _productService.UpdateProductAsync(id,productRequestModel);
            if (updateProduct == null)
            {
                return BadRequest("Product doesnt exists or the category doesnt exist");
            }
            else
            {
                return Ok(productRequestModel);
            }
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            var deleteProdcut = await _productService.DeleteProductAsync(id);
            if (deleteProdcut == null)
            {
                return BadRequest("Couldnt delete product");
            }
            else
            {
                return Ok("Product delete succesfully");
            }
        }
    }
}
