using Microsoft.EntityFrameworkCore;
using TODOApi.Models;

namespace TODOApi.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItemPriority>().HasData(
               new TodoItemPriority
               {
                   PriorityId = 1,
                   Title = "Low"
               },
               new TodoItemPriority
               {
                   PriorityId = 2,
                   Title = "Medium"
               },
               new TodoItemPriority
               {
                   PriorityId = 3,
                   Title = "High"
               }
               );
        }
    }
}
