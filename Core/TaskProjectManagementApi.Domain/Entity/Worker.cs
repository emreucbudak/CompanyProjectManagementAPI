using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Common;

namespace TaskProjectManagementApi.Domain.Entity
{
    public class Worker 
    {
       public int WorkerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsLeaved { get; set; }
        public int CompanyId { get; set; }  
        public Company Company { get; set; }

    }
}
