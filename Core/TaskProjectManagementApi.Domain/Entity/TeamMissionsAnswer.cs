using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Common;

namespace TaskProjectManagementApi.Domain.Entity
{
    public class TeamMissionsAnswer  : BaseEntity
    {
        public int TeamMissionsId { get; set; }
        public TeamMissions TeamMissions { get; set; }
        public string Answer { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }  
    }
}
