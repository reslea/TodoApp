using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Ifrastructure.Entities;
using TodoApp.Ifrastructure.Repositories;
using TodoApp.Ifrastructure.Services;

namespace TodoApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Todo dbTodo)
        {
            await _repository.Add(dbTodo);
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            return await _repository.Get();
        }
    }
}
