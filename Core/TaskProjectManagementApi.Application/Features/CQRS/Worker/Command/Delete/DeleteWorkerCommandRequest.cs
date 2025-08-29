using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.Worker.Command.Delete
{
    public class DeleteWorkerCommandRequest : IRequest
    {
        public int WorkerId { get; set; }
    }
}
