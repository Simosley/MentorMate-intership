using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOApi.Models;

namespace TODOApi.Data.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoContext _context;
        public TodoItemRepository(TodoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TodoItem>> GetAllTodoItems()
        {
            var allTodoItems = await _context.TodoItems.Include(p => p.TodoItemPriority).ToListAsync();
            return allTodoItems;
        }

        public async Task<TodoItem> GetTodoItemById(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            return todoItem;
        }


        public async Task<TodoItem> AddTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;

        }

        public async Task<TodoItem> UpdateTodoItem(int id, TodoItem todoItem)
        {
            _context.TodoItems.Update(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;
        }

        

        public async Task<IEnumerable<TodoItemPriority>> GetTodoItemPriority()
        {
            return await _context.TodoItemsPriority.ToListAsync();
        }

        public async Task<TodoItem> DeleteTodoItem(int id,TodoItem todoItem)
        {
           var findItem = await _context.TodoItems.FindAsync(id);
            _context.TodoItems.Remove(findItem);
            await _context.SaveChangesAsync();
            return findItem;
           
        }
    }
}
