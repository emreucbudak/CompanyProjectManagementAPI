using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Common;

namespace TaskProjectManagementApi.Domain.Entity
{
    public class Team : BaseEntity
    {
        public ICollection<Worker> Workers { get; set; } 
        public bool IsAvailable { get; set; }   


    }
}
