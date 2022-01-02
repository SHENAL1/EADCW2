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

        
        public string ProjectName { get; set; }

        
        public string ProjectDescription { get; set; }

        
        public string StartDate { get; set; }

        
        public string EndDate { get; set; }

        public string ProjectStatus { get; set; }
        
        public User User { get; set; }

    }
}
