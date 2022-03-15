using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ResturantApi.Domain.Entities.Status;

namespace ResturantApi.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey("Table")]
        public int? TableId { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public string Username { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public Status Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        public virtual Table Table { get; set; }
        public virtual Product Product { get; set; }
    }
}
