using Microsoft.Extensions.Hosting;
using System.Net.Http.Json;
using ApiCrudToDo.Models;

namespace ApiCrudToDo.Services
{
    public class JsonPlaceholderService
    {
        private readonly HttpClient _httpClient;
        private const string URL = "https://dummyjson.com/todos";

        public JsonPlaceholderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TodoModel>> GetTodosAsync()
        {
            var response = await _httpClient.GetAsync(URL);
            response.EnsureSuccessStatusCode();
            var todos = await response.Content.ReadFromJsonAsync<TodosList>();
            return todos.todos;
        }

        public async Task<TodoModel> GetTodoAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{URL}/{id}");
            response.EnsureSuccessStatusCode();
            var todo = await response.Content.ReadFromJsonAsync<TodoModel>();
            return todo;
        }

        public async Task<TodoModel> CreateTodoAsync(TodoModel newTodo)
        {
            var response = await _httpClient.PostAsJsonAsync(URL, newTodo);
            response.EnsureSuccessStatusCode();
            var createdTodo = await response.Content.ReadFromJsonAsync<TodoModel>();
            return createdTodo;
        }

        public async Task UpdateTodoAsync(int id, TodoModel updatedTodo)
        {
            var response = await _httpClient.PutAsJsonAsync($"{URL}/{id}", updatedTodo);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteTodoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{URL}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

