using ResturantApi.Domain.Entities;

namespace ResturantApi.Domain.Models
{
    public class TableResponseModel
    {
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public TableStatus TableStatus { get; set; }
        public int Capacity { get; set; }
        public string Username { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
