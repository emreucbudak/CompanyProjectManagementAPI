using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissions.Queries.GetAllQueries
{
    public class GetAllTeamMissionsQueriesRequest : IRequest<List<GetAllTeamMissionsQueriesResponse>>
    {
        public int CompanyId { get; set; }
    }
}
