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
        public int TicketId { get; set; } = 0;

        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "The Ticket Name should be 5-30 characters.")]
        public string TicketName { get; set; }

        [StringLength(200, MinimumLength = 10, ErrorMessage = "The Ticket Description should be 10-200 characters.")]
        public string TicketDescription { get; set; }

        [Required (ErrorMessage = "Select the Ticket Status")]
        public string TicketStatus { get; set; }

        //[Required]
        //[StringLength(100, MinimumLength = 3, ErrorMessage = "Enter the Project Name which this ticket is included (3-100 characters)")]
        //public string ProjectName { get; set; }

        //[StringLength(200, MinimumLength = 3, ErrorMessage = "Enter the User's Name to which this ticket is assigned to (3-100 characters)")]
        //public string UserName { get; set; }

        //public Project Project { get; set; }

        //public User User { get; set; }

    }
}
