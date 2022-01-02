using CW2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CW2.Client.Services
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient _httpClient;

        public event Action OnChange;

        public ProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Project> Projects { get; set; } = new List<Project>();

        public async Task<Project> GetSingleProject(int id)
        {
            return await _httpClient.GetFromJsonAsync<Project>($"api/project/{id}");
        }

        public async Task<List<Project>> GetProjects()
        {
            
            Projects= await _httpClient.GetFromJsonAsync<List<Project>>("api/project");
            return Projects;
        }

        public async Task<List<Project>> CreateProject(Project project)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/project", project);
            Projects = await result.Content.ReadFromJsonAsync<List<Project>>();
            OnChange.Invoke();
            return Projects;
        }

        public async Task<List<Project>> UpdateProject(Project project, int id)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/project/{id}", project);
            Projects = await result.Content.ReadFromJsonAsync<List<Project>>();
            OnChange.Invoke();
            return Projects;
        }
    }
}
