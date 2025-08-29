using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissions.Command.Command.Delete
{
    public class DeleteIndividualMissionsCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}
