using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Ifrastructure.Entities;

namespace TodoApp.Ifrastructure.Repositories
{
    public interface ITodoRepository : IRepository<Todo>
    {
        Task<IEnumerable<Todo>> Get(Func<Todo, bool> predicate);
    }
}
