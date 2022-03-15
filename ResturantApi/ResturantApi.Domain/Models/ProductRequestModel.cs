using System.ComponentModel.DataAnnotations;

namespace ResturantApi.Domain.Models
{
    public class ProductRequestModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
