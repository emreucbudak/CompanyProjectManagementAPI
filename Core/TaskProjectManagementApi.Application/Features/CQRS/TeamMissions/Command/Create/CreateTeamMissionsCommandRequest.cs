using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissions.Command.Create
{
    public class CreateTeamMissionsCommandRequest : IRequest
    {
        public string MissionTitle { get; set; }
        public string MissionDescription { get; set; }
        public int MissionStatusId { get; set; }
        public int TeamId { get; set; }
    }
}
