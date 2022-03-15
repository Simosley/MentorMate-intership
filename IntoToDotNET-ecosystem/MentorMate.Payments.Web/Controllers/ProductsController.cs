using MentorMate.Payments.Business.Services;
using MentorMate.Payments.Business.Providers;
using MentorMate.Payments.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace MentorMate.Payments.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProducts")]
        public  List<Product> Get()
        {

            IProductService Service = new ProductService();
            var products = Service.GetProducts();
            return products;  
        }
    }
}