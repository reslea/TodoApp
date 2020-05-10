using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Ifrastructure.Entities;

namespace TodoApp.Ifrastructure.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllAsync();

        Task Create(Todo dbTodo);
    }
}
