using ResturantApi.Domain.Entities;

namespace ResturantApi.Domain.Models
{
    public class OrderResponseModelItems
    {
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public int ProductId { get; set; }
        public decimal TotalPrice { get; set; }
        public Status Status { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
