using System;
using TodoApp.Repositories;
using Xunit;
using Moq;
using TodoApp.Ifrastructure.Repositories;
using TodoApp.Ifrastructure.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Services;

namespace TodoApp.Tests
{
    public class TodoServiceTests
    {
        private List<Todo> todoItems = new List<Todo>() { new Todo { Title = "Some", IsDone = true } };
        private Mock<ITodoRepository> mockTodoRepository = new Mock<ITodoRepository>(MockBehavior.Strict);

        [Fact(DisplayName = "Service returns all requested items")]
        public async void ServiceReturnsAllRequestedItems()
        {
            mockTodoRepository
                .Setup(r => r.Get(It.IsAny<Func<Todo, bool>>()))
                .Returns(Task.FromResult(todoItems.AsEnumerable()));

            var serviceToTest = new TodoService(mockTodoRepository.Object);

            var counter = 0;
            Assert.All(await serviceToTest.GetAllAsync(), todo => Assert.Equal(todoItems[counter++].Title, todo.Title));
        }

        [Fact(DisplayName = "Create adds new todo")]
        public async void CreateAddsNewTodo()
        {
            mockTodoRepository
                .Setup(r => r.Add(It.IsAny<Todo>()))
                .Returns((Todo newItem) =>
                {
                    todoItems.Add(newItem);
                    return Task.CompletedTask;
                });
            mockTodoRepository.VerifyNoOtherCalls();

            var serviceToTest = new TodoService(mockTodoRepository.Object);
            var newTodo = new Todo { Title = "Check" };
            
            await serviceToTest.Create(newTodo);

            Assert.Contains(todoItems, t => t.Title == newTodo.Title);
        }
    }
}
