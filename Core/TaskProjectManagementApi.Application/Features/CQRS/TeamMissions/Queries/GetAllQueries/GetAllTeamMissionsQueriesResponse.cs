using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissions.Queries.GetAllQueries
{
    public class GetAllTeamMissionsQueriesResponse
    {
        public string MissionTitle { get; set; }
        public string MissionDescription { get; set; }
        public string StatusName { get; set; }
        public string TeamName { get; set; }
    }
}
