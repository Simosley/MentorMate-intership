using System.ComponentModel.DataAnnotations;

namespace ResturantApi.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [MaxLength(100)]
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> Children { get; set; }
    }
}
