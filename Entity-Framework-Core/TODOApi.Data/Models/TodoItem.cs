using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TODOApi.Data.Models.Status;

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
        
        public status StatusEnum { get; set; }

        [ForeignKey("TodoItemPriority")]
        public int TodoItemPriorityId { get; set; }
        public virtual TodoItemPriority TodoItemPriority { get; set; }
       
    }
}
