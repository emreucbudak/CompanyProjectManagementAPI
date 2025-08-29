using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissionsAnswer.Command.Create
{
    public class CreateTeamMissionsAnswerCommandRequest  : IRequest
    {
        public string Answer { get; set; }
        public int WorkerId { get; set; }
        public int TeamMissionsId { get; set; }
    }
}
