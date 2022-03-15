using static TODOApi.Data.Models.Status;

namespace TODOApi.Models
{
    public class ResponseModelTodoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public status StatusEnum { get; set; }

        public string TodoItemPriorityName{ get; set; }

    }
}
