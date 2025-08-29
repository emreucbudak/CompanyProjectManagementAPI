using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.AllReports.Queries.GetAllByIdWorker
{
    public class GetAllReportsByIdForWorkerQueriesRequest : IRequest<List<GetAllReportsByIdForWorkerQueriesResponse>>
    {
        public int WorkerId { get; set; }
    }
}
