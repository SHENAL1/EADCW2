using CW2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW2.Client.Services
{
    public interface ITicketService
    {
        event Action OnChange;
        List<Ticket> Tickets { get; set; }

        Task<List<Ticket>> GetTickets();

        Task<Ticket> GetSingleTicket(int id);

        Task<List<Ticket>> CreateTicket(Ticket ticket);

        Task<List<Ticket>> UpdateTicket(Ticket ticket, int id);

        Task<List<Ticket>> DeleteTicket(int id);
    }
}
