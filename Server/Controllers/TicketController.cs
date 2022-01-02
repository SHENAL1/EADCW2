using CW2.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        static List<Ticket> tickets = new List<Ticket>
        {
            new Ticket { TicketId=1, TicketDescription = "Create Home Page", TicketStatus ="Completed"},
            new Ticket { TicketId=2, TicketDescription = "Create Payment Gateway", TicketStatus ="Inprogress"}
        };

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleTicket(int id)
        {
            var ticket = tickets.FirstOrDefault(t => t.TicketId == id);
            if (ticket == null)
            {
                return NotFound("The Ticket is not in the system");
            }
            else
            {
                return Ok(ticket);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {
            ticket.TicketId = tickets.Max(t => t.TicketId + 1);
            tickets.Add(ticket);

            return Ok(tickets);
            

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(Ticket ticket, int id)
        {
            var dbTicket = tickets.FirstOrDefault(t => t.TicketId == id);
            if (dbTicket == null)
            {
                return NotFound("The Ticket is not in the system");
            }

            dbTicket = ticket;

            return Ok(tickets);


        }
    }
}
