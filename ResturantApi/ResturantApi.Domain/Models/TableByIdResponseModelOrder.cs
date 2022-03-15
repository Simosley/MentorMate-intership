using ResturantApi.Domain.Entities;

namespace ResturantApi.Domain.Models
{
    public class TableByIdResponseModelOrder
    {
        public int OrderId { get; set; }
        public string Username { get; set; }
        public Status Status { get; set; }
        public decimal TotalPrice { get; set; }
        public List<TableByIdResponseModelProducts> Products { get; set; }
    }
}
