using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2.Shared
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        
        public string TicketDescription { get; set; }

        public string TicketStatus { get; set; }

        public Project Project { get; set; }

        public User User { get; set; }

    }
}
