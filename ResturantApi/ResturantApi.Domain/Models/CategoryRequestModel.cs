using System.ComponentModel.DataAnnotations;

namespace ResturantApi.Domain.Models
{
    public class CategoryRequestModel
    {
        [MaxLength(100)]
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
