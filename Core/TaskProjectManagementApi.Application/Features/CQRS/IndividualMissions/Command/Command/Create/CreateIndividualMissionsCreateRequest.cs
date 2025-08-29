using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissions.Command.Command.Create
{
    public class CreateIndividualMissionsCreateRequest : IRequest
    {
        public int WorkerId { get; set; }
        public string MissionTitle { get; set; }
        public string MissionDescription { get; set; }
        public int MissionStatusId { get; set; }
    }
}
