using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Common;

namespace TaskProjectManagementApi.Domain.Entity
{
    public class TeamMissions : BaseEntity
    {
        public TeamMissions()
        {
        }

        public TeamMissions(string missionTitle, string missionDescription, int missionStatusId, int teamId)
        {
            MissionTitle = missionTitle;
            MissionDescription = missionDescription;
            MissionStatusId = missionStatusId;
            TeamId = teamId;
        }

        public string MissionTitle { get; set; }
        public string MissionDescription { get; set; }
        public int MissionStatusId { get; set; }
        public MissionStatus MissionStatus { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }

    }
}
