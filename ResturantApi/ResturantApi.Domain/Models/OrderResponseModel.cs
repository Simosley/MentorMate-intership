namespace ResturantApi.Domain.Models
{
    public class OrderResponseModel
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalOrders { get; set; }
        public List<OrderResponseModelItems> Items { get; set; }
    }
}
