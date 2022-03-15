using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOApi.Domain.Models
{
    public class TodoItem
    {
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status StatusEnum { get; set; }
        public int TodoItemPriorityPriorityId { get; set; }
        public enum Status
        {
            Pending,
            inProgress,
            Complete
        }
    }
}
