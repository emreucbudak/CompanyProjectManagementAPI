using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.ReporterWorker.Command.Delete
{
    public class DeleteReporterWorkerCommandRequest : IRequest
    {
        public int reporterWorkerId { get; set; }
    }
}
