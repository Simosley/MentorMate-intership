using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOApi.Data.Repositories;
using TODOApi.Models;

namespace TODOApi.Business.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemService(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }
        public async Task<List<TodoItem>> GetAllTodoItems()
        {
            var todoItemsTable = await _todoItemRepository.GetAllTodoItems();
            var todoItems = todoItemsTable.OrderByDescending(i => i.TodoItemPriorityId);

            return todoItems.ToList();
        }

        public async Task<TodoItem> GetTodoItemById(int id)
        {
            var itemsById = await _todoItemRepository.GetTodoItemById(id);
            return itemsById;
        }

        public async Task<TodoItem> AddTodoItem(TodoItem todoItem)
        {
            var addItem = await _todoItemRepository.AddTodoItem(todoItem);
            return addItem;
        }

        public async Task<TodoItem> UpdateTodoItem(int id, TodoItem todoItem)
        {
            var updateItem = await _todoItemRepository.UpdateTodoItem(id,todoItem);
            return updateItem;
        }

        public async Task<TodoItem> DeleteTodoItem(int id, TodoItem todoItem)
        {
            var removeItem = await _todoItemRepository.DeleteTodoItem(id,todoItem);
            return removeItem;
        }

       
    }
}
