using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissionsAnswer.Queries
{
    public class GetAllTeamMissionsAnswerQueriesResponse
    {
        public string Answer { get; set; }
        public List<string> WorkerName { get; set; }
        public string StatusName { get; set; }  
        public string MissionName { get; set; }
        public string TeamName { get; set; }    

    }
}
