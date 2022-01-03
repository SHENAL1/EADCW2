using CW2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CW2.Client.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly HttpClient _httpClient;

        public event Action OnChange;

        public CompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Company> Companies { get; set; } = new List<Company>();

        public async Task<Company> GetSingleCompany(int id)
        {
            return await _httpClient.GetFromJsonAsync<Company>($"api/company/{id}");
        }

        public async Task<List<Company>> GetCompanies()
        {
            Companies = await _httpClient.GetFromJsonAsync<List<Company>>("api/company");
            return Companies;
        }

        public async Task<List<Company>> CreateCompany(Company company)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/company", company);
            Companies = await result.Content.ReadFromJsonAsync<List<Company>>();
            OnChange.Invoke();
            return Companies;
            
        }

        public async Task<List<Company>> UpdateCompany(Company company, int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/company/{id}", company);
            Companies = await result.Content.ReadFromJsonAsync<List<Company>>();
            OnChange.Invoke();
            return Companies;
        }

        public async Task<List<Company>> DeleteCompany(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/company/{id}");
            Companies = await result.Content.ReadFromJsonAsync<List<Company>>();
            OnChange.Invoke();
            return Companies;
        }
    }
}
