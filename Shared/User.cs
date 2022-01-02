using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2.Shared
{
    public class User
    {
        [Key]
        public int UserId { get; set; } = 0;

        
        public string UserName { get; set; }

        
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
        public string UserEmail { get; set; }

        
        public string UserPhoneNo { get; set; }

        
        public string UserType { get; set; }
        
        public Company Company { get; set; }
    }
}
