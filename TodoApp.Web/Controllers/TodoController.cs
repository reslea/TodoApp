using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApp.EF;
using TodoApp.Ifrastructure.Entities;
using TodoApp.Ifrastructure.Services;
using TodoApp.Web.Models;

namespace TodoApp.Web.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;
        private readonly TodoDbContext _context;
        private readonly ILogger<TodoController> _logger;

        public TodoController(
            ILogger<TodoController> logger, 
            IMapper mapper, 
            ITodoService todoService, 
            TodoDbContext context)
        {
            _todoService = todoService;
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("trying to retrieve todos...");

            IEnumerable<Todo> dbTodos = await _todoService.GetAllAsync();

            _logger.LogInformation("{0} todos retreived successfully", dbTodos.Count());

            var models = _mapper.Map<IEnumerable<TodoModel>>(dbTodos);

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TodoModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("invalid form was submitted");
                return View("Error", new ErrorViewModel());
            }

            var dbTodo = _mapper.Map<Todo>(model);

            _logger.LogInformation("trying to create todo...");

            await _todoService.Create(dbTodo);
            await _context.SaveChangesAsync();

            _logger.LogInformation("todo with Id {0} created successfully", dbTodo.Id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(TodoModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("invalid form was submitted");
                return View("Error", new ErrorViewModel());
            }

            var dbTodo = _mapper.Map<Todo>(model);
            await _todoService.Edit(dbTodo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}