using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissions.Command.Delete
{
    public class DeleteTeamMissionsCommandRequest : IRequest
    {
        public int TeamId { get; set; }

    }
}
