using E01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E01.Data
{
    public class CloudTodoService : ITodoService
    {
        private readonly HttpClient client;
        private string uri = "http://localhost:5003";
            

        public CloudTodoService()
        {
          client = new HttpClient();

        }
        public async Task<IList<Todo>> GetTodosAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/todos");
            string message = await stringAsync;
            List<Todo> result = JsonSerializer.Deserialize<List<Todo>>(message);
            return result;
        }
        public async Task AddTodoAsync(Todo todo)
        {
            string todoAsJson = JsonSerializer.Serialize(todo);
            HttpContent content = new StringContent(todoAsJson, Encoding.UTF8, "application/json");
            await client.PostAsync(uri + "/todos", content);
        }

       

        public async Task RemoveTodoAsync(int todoId)
        {
            await client.DeleteAsync($"{uri}/todos/{todoId}");
        }

        public async Task UpdateAsync(Todo todo)
        {
            string todoAsJson = JsonSerializer.Serialize(todo);
            HttpContent content = new StringContent(todoAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/todos/{todo.TodoId}", content);
        }
    }
}
