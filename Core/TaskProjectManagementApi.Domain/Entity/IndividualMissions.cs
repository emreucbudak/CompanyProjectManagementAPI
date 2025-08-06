using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Common;

namespace TaskProjectManagementApi.Domain.Entity
{
    public class IndividualMissions : BaseEntity
    {
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public string MissionTitle { get; set; }
        public string MissionDescription { get; set; }
        public int MissionStatusId { get; set; } 
        public MissionStatus MissionStatus { get; set; }
    }
}
