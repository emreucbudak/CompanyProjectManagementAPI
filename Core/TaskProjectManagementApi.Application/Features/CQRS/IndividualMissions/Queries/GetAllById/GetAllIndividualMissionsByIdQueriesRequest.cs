using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissions.Queries.GetAllById
{
    public class GetAllIndividualMissionsByIdQueriesRequest : IRequest<List<GetAllIndividualMissionsQueriesResponse>>
    {
        public int WorkerId { get; set; }
    }
}
