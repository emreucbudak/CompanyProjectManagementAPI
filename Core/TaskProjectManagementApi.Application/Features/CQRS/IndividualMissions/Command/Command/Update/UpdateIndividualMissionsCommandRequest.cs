using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissions.Command.Command.Update
{
    public class UpdateIndividualMissionsCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string MissionTitle { get; set; }
        public string MissionDescription { get; set; }
 
    }
}
