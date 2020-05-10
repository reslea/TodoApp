using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.EF;
using TodoApp.Ifrastructure.Entities;
using TodoApp.Ifrastructure.Repositories;

namespace TodoApp.Repositories
{
    public class TodoRepository : Repository<Todo>, ITodoRepository
    {
        public TodoRepository(TodoDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Todo>> Get(Func<Todo, bool> predicate)
        {
            return await Task.Run(() => _dbSet.Where(predicate));
        }
    }
}
