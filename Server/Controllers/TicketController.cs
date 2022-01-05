using CW2.Server.Data;
using CW2.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            new Ticket { TicketId=1, TicketName="Ticket1", TicketDescription = "Create Home Page", TicketStatus ="Completed"},
            new Ticket { TicketId=2, TicketName="Ticket2", TicketDescription = "Create Payment Gateway", TicketStatus ="Inprogress"}
        };
        private readonly ApplicationDbContext _context;

        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            return base.Ok(await GetDbTickets());
        }

        private async Task<List<Ticket>> GetDbTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleTicket(int id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.TicketId == id);
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
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return Ok(await GetDbTickets());
            

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(Ticket ticket, int id)
        {
            var dbTicket = await _context.Tickets.FirstOrDefaultAsync(t => t.TicketId == id);
            if (dbTicket == null)
            {
                return NotFound("The Ticket is not in the system");
            }

            dbTicket.TicketId = ticket.TicketId;
            dbTicket.TicketName = ticket.TicketName;
            dbTicket.TicketDescription = ticket.TicketDescription;
            dbTicket.TicketStatus = ticket.TicketStatus;
            dbTicket.ProjectName = ticket.ProjectName;
            dbTicket.UserName = ticket.UserName;

            await _context.SaveChangesAsync();
            return Ok(await GetDbTickets());


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var dbTicket = await _context.Tickets.FirstOrDefaultAsync(t => t.TicketId == id);
            if (dbTicket == null)
            {
                return NotFound("The Ticket is not in the system");
            }

            _context.Tickets.Remove(dbTicket);
            await _context.SaveChangesAsync();
            return Ok(await GetDbTickets());


        }
    }
}
