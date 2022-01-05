using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2.Shared
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; } = 0;

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The Project Name should be 3-30 characters.")]
        public string ProjectName { get; set; }

        [StringLength(30, MinimumLength = 5, ErrorMessage = "The Company Description should be 5-30 characters.")]
        public string ProjectDescription { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "The Start Date should be DD/MM/YYYY format")]
        public string StartDate { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "The End Date should be DD/MM/YYYY format")]
        public string EndDate { get; set; }

        [Required(ErrorMessage = "Select the Ticket Status")]
        public string ProjectStatus { get; set; }


        //[StringLength(30, MinimumLength = 3, ErrorMessage = "Enter the User's Name to which this project is assigned to (3-30 characters)")]
        //public string UserName { get; set; }

        //[StringLength(100, MinimumLength = 3, ErrorMessage = "Enter the Company Name which this ticket is included (3-100 characters)")]
        //public string CompanyName { get; set; }

        //public Company CompanyId { get; set; }
        //public User User { get; set; }

    }
}
