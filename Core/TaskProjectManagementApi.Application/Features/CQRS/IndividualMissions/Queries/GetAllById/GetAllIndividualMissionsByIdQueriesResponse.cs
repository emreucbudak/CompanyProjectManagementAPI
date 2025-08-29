using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissions.Queries.GetAllById
{
    public class GetAllIndividualMissionsQueriesResponse
    {
        public string MissionTitle { get; set; }
        public string MissionDescription { get; set; }
        public string StatusName { get; set; }
    }
}
