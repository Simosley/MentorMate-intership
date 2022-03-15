using System.ComponentModel.DataAnnotations;
using static TODOApi.Models.Enums;

namespace TODOApi.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        public Priority Priority{ get; set; }
        public Status Status { get; set; }
        
    }
}
