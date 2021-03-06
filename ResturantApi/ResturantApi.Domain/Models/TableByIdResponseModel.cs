using ResturantApi.Domain.Entities;

namespace ResturantApi.Domain.Models
{
    public class TableByIdResponseModel
    {
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public TableStatus TableStatus { get; set; }
        public int Capacity { get; set; }
        public List<TableByIdResponseModelOrder> Order { get; set; }
    }
}
