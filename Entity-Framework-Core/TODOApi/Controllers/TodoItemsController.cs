#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TODOApi.Data;
using TODOApi.Models;
using TODOApi.Business.Services;
using TODOApi.Models;
using AutoMapper;

namespace TODOApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;
        private readonly IMapper _mapper;
        public TodoItemsController(ITodoItemService todoItemService,IMapper mapper)
        {
            _todoItemService = todoItemService;
            _mapper = mapper;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<IActionResult> GetTodoItems()
        {
            var todoItems = await _todoItemService.GetAllTodoItems();
            var responseModel = todoItems.Where(x => x.TodoItemPriorityId == x.TodoItemPriority.PriorityId).Select(x => new ResponseModelTodoItem()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                StatusEnum = x.StatusEnum,
                TodoItemPriorityName = x.TodoItemPriority.Title
            });
            return Ok(responseModel);
        }
        [HttpPost]
        public async Task<ActionResult> AddTodoItem(RequestModelTodoItem requestModelTodoItem)
        {

            var mapItem = _mapper.Map<TodoItem>(requestModelTodoItem);
            var addItem = await _todoItemService.AddTodoItem(mapItem);
            return Ok(addItem);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTodoItem(int id)
        {
            var todoItemsById = await _todoItemService.GetTodoItemById(id);
            return Ok(todoItemsById);
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(int id, RequestModelTodoItem requestModelTodoItem)
        {
            var mapItem = _mapper.Map<TodoItem>(requestModelTodoItem);
            var updateItem = await _todoItemService.UpdateTodoItem(id, mapItem);
            return Ok(updateItem);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id, RequestModelTodoItem requestModelTodoItem)
        {
            var mapItem = _mapper.Map<TodoItem>(requestModelTodoItem);
            var removeItem = await _todoItemService.DeleteTodoItem(id, mapItem);
            return Ok(removeItem);
        }
    }
}
