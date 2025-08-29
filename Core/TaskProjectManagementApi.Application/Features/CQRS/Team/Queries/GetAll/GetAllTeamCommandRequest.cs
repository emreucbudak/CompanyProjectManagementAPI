using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.Team.Queries.GetAll
{
    public class GetAllTeamCommandRequest : IRequest<List<GetAllTeamCommandResponse>>
    {
        public int CompanyId { get; set; }
    }
}
