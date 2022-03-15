using System.ComponentModel.DataAnnotations;
using static ResturantApi.Domain.Entities.TableStatus;

namespace ResturantApi.Domain.Entities
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public TableStatus TableStatus { get; set; }
        [Range(2,12)]
        public int Capacity { get; set; }

    }
}
