using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.ReporterWorker.Queries.GetAll
{
    public class GetAllReporterWorkerQueriesRequest : IRequest<List<GetAllReporterWorkerQueriesResponse>>
    {
    }
}
