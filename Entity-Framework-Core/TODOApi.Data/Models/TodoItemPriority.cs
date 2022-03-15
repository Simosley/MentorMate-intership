using System.ComponentModel.DataAnnotations;

namespace TODOApi.Models
{
    public class TodoItemPriority
    {
        [Key]
        public int PriorityId { get; set; }
        public string Title { get; set; }
    }
}
