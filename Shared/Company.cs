using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2.Shared
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; } = 0;

        [StringLength(30, MinimumLength=5, ErrorMessage = "The Company name should be 5-30 characters.")]
        public string CompanyName { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "The Company address should be 5-100 characters.")]
        public string CompanyAddress { get; set; }

        [StringLength(30, MinimumLength = 5, ErrorMessage = "The Company Email should be 5-30 characters.")]
        public string CompanyEmail { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "The Company Phone number should have 10 digits.")]
        public string CompanyPhoneNo { get; set; }

        [StringLength(200, MinimumLength = 10, ErrorMessage = "The Company Description should be 10-200 characters.")]
        public string CompanyDescription { get; set; }
    }
}
