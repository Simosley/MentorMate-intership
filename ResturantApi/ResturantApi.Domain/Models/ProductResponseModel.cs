namespace ResturantApi.Domain.Models
{
    public class ProductResponseModel
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalProducts { get; set; }
        public List<ProductResponseModelItems> Items { get; set; }
    }
}
