using Microsoft.EntityFrameworkCore;
using TODOApi.Models;

namespace TODOApi.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options): base(options) { }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoItemPriority> TodoItemsPriority { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

    }
}
