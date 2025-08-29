using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissionsAnswer.Queries.GetById
{
    public class GetIndividualMissionsAnswerByIdCommandRequest : IRequest<GetIndividualMissionsAnswerByIdCommandResponse>
    {
        public int IndividualMissionsId { get; set; }
    }
}
