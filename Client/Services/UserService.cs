using CW2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace CW2.Client.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public event Action OnChange;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<User> Users { get; set; } = new List<User>();

        public async Task<User> GetSingleUser(int id)
        {
            return await _httpClient.GetFromJsonAsync<User>($"api/user/{id}");
        }

        public async Task<List<User>> GetUsers()
        {

            Users = await _httpClient.GetFromJsonAsync<List<User>>("api/user");
            return Users;
        }

        public async Task<List<User>> CreateUser(User user)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/user", user);
            Users = await result.Content.ReadFromJsonAsync<List<User>>();
            OnChange.Invoke();
            return Users;
        }

        public async Task<List<User>> UpdateUser(User user, int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/user/{id}", user);
            Users = await result.Content.ReadFromJsonAsync<List<User>>();
            OnChange.Invoke();
            return Users;
        }

        public async Task<List<User>> UDeleteUser(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/user/{id}");
            Users = await result.Content.ReadFromJsonAsync<List<User>>();
            OnChange.Invoke();
            return Users;
        }
    }
}
