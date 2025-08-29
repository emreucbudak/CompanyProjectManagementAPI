using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissionsAnswer.Command.Delete
{
    public class DeleteTeamMissionsAnswerCommandRequest : IRequest
    {
        public int TeamMissionsAnswerId { get; set; }

    }
}
