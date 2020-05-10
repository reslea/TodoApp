using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Ifrastructure.Entities;
using TodoApp.Ifrastructure.Repositories;
using TodoApp.EF;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TodoApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TodoDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(TodoDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await Task.FromResult(_dbSet.AsEnumerable());
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
