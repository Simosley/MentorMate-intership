using static TODOApi.Data.Models.Status;

namespace TODOApi.Models
{
    public class RequestModelTodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public status StatusEnum { get; set; }
        public int TodoItemPriorityId { get; set; }
        
    }
}
