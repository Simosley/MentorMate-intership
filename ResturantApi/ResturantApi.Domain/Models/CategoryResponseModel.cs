namespace ResturantApi.Domain.Models
{
    public class CategoryResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> SubCategories { get; set; }
    }
}
