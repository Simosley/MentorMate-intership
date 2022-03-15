using ResturantApi.Domain.Entities;

namespace ResturantApi.Domain.Models
{
    public class OrderByIdResponseModel
    {
        public int TableId { get; set; }
        public string Username { get; set; }
        public Status Status { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderByIdResponseModelProps> Products { get; set; }
    }
}
