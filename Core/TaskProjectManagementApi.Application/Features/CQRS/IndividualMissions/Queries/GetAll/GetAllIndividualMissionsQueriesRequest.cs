using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissions.Queries.GetAll
{
    public class GetAllIndividualMissionsQueriesRequest : IRequest<List<GetAllIndividualMissionsQueriesResponse>>
    {
        public int CompanyId { get; set; }
    }
}
