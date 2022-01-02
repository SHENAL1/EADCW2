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
        public int CompanyId { get; set; }

        
        public string CompanyName { get; set; }

        
        public string CompanyAddress { get; set; }

        
        public string CompanyEmail { get; set; }

        
        public string CompanyPhoneNo { get; set; }

        public string CompanyDescription { get; set; }
    }
}
