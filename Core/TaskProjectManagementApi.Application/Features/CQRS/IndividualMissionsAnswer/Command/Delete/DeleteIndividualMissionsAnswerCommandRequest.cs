using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissionsAnswer.Command.Delete
{
    public class DeleteIndividualMissionsAnswerCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}
