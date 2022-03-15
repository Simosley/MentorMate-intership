using AutoMapper;
using TODOApi.Models;
namespace TODOApi.Helpers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<RequestModelTodoItem, TodoItem>();
            CreateMap<ResponseModelTodoItem, TodoItem>();
        }
    }
}
