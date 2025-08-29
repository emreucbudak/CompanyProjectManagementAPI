using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissions.Command.Update
{
    public class UpdateTeamMissionsCommandRequest : IRequest
    {
        public int TeamId { get; set; }

    }
}
