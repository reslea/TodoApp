using System;
using TodoApp.Repositories;
using Xunit;
using TodoApp.Ifrastructure.Repositories;
using TodoApp.Ifrastructure.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TodoApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using TodoApp.Web;

namespace TodoApp.Tests
{
    public class Integration
    {
        private readonly HttpClient _todoAppClient;
        public Integration()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseSetting("ConnectionString", @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Todos_Test;Integrated Security=True;")
                .UseStartup<Startup>();

            var server = new TestServer(webHostBuilder);
            _todoAppClient = server.CreateClient();
        }

        [Fact(DisplayName = "[Post] Create todo")]
        public async void CreateTodo()
        {
            var identifier = Guid.NewGuid();
            var newTodo = new Todo
            {
                Title = "test todo " + identifier
            };
            var formContent = new MultipartFormDataContent {
            {
                new StringContent(newTodo.Title), "title"
            }};

            var response = await _todoAppClient.PostAsync("/todo/create", formContent);

            Assert.True(response.StatusCode == HttpStatusCode.Found);

            var redirectUrl = response.Headers.Location;

            var html = await _todoAppClient.GetStringAsync(redirectUrl);
            Assert.Contains(identifier.ToString(), html);
        }
    }
}
