using CW2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CW2.Client.Services
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient _httpClient;

        public TicketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();

        public event Action OnChange;

        

        public async Task<Ticket> GetSingleTicket(int id)
        {
            return await _httpClient.GetFromJsonAsync<Ticket>($"api/ticket/{id}");
        }

        public async Task<List<Ticket>> GetTickets()
        {
            Tickets = await _httpClient.GetFromJsonAsync<List<Ticket>>("api/ticket");
            return Tickets;
        }

        public async Task<List<Ticket>> CreateTicket(Ticket ticket)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/ticket", ticket);
            Tickets = await result.Content.ReadFromJsonAsync<List<Ticket>>();
            OnChange.Invoke();
            return Tickets;
        }

        public async Task<List<Ticket>> UpdateTicket(Ticket ticket, int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/ticket/{id}", ticket);
            Tickets = await result.Content.ReadFromJsonAsync<List<Ticket>>();
            OnChange.Invoke();
            return Tickets;
        }

        public async Task<List<Ticket>> DeleteTicket(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/ticket/{id}");
            Tickets = await result.Content.ReadFromJsonAsync<List<Ticket>>();
            OnChange.Invoke();
            return Tickets;
        }
    }

}
