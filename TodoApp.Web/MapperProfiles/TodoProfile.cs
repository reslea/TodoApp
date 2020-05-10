using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TodoApp.Ifrastructure.Entities;
using TodoApp.Web.Models;

namespace TodoApp.Web.MapperProfiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile() : base()
        {
            CreateMap<TodoModel, Todo>()
                .AfterMap((model, todo) =>
                {
                    if (model.DueDate == default)
                        todo.DueDate = DateTime.Now.AddDays(1);
                });
            CreateMap<Todo, TodoModel>();
        }
    }
}
