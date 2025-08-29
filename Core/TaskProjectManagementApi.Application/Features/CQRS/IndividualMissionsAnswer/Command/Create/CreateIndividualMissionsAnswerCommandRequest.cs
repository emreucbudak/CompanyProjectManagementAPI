using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissionsAnswer.Command.Create
{
    public class CreateIndividualMissionsAnswerCommandRequest : IRequest
    {
        public string Answer { get; set; }
        public int AnswerStatusId { get; set; }
        public int IndividualMissionId { get; set; }

    }
}
