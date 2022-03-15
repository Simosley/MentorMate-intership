using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResturantApi.Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "_Name is required and must not exceed 100 characters_")]

        public string ProductName { get; set; }
        [MaxLength(500, ErrorMessage = "_The product description must not exceed 500 characters_")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
