namespace ResturantApi.Domain.Models
{
    public class OrderRequestModel
    {
        public int TableId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
