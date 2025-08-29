using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissionsAnswer.Queries
{
    public class GetAllTeamMissionsAnswerQueriesRequest : IRequest<List<GetAllTeamMissionsAnswerQueriesResponse>>
    {
        public int TeamId { get; set; }
    }
}
