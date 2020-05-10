using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Ifrastructure.Entities;

namespace TodoApp.Data
{
    public class TodoDbContext : DbContext
    {
        DbSet<Todo> Todos { get; set; }

        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }
    }
}
