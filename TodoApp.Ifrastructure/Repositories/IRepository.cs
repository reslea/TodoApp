using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Ifrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();

        Task<T> Get(int id);

        Task Add(T entity);

        Task Update(T entity);

        Task Delete(T entity);
    }
}
