using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissionsAnswer.Command.Update
{
    public class UpdateTeamMissionsAnswerCommandRequest : IRequest
    {
        public int TeamMissionsAnswerId { get; set; }
        public int statusId { get; set; }
    }
}
