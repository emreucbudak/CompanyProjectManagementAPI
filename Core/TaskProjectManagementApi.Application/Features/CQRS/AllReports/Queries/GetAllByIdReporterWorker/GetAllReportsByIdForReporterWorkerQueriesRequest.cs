using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.AllReports.Queries.GetAllByIdReporterWorker
{
    public class GetAllReportsByIdForReporterWorkerQueriesRequest : IRequest<List<GetAllReportsByIdForReporterWorkerQueriesResponse>>
    {
        public int ReporterWorkerId { get; set; }
    }
}
