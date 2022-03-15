using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOApi.Models;

namespace TODOApi.Business.Services
{
    public interface ITodoItemService
    {
        Task<List<TodoItem>> GetAllTodoItems();

        Task<TodoItem> GetTodoItemById(int id);

        Task<TodoItem> AddTodoItem(TodoItem todoItem);

        Task<TodoItem> UpdateTodoItem(int id, TodoItem todoItem);

        Task<TodoItem> DeleteTodoItem(int id, TodoItem todoItem);
    }
}
