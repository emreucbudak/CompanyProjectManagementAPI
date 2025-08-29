using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.ReporterWorker.Queries.GetByCompanyId
{
    public class GetReporterWorkerByCompanyIdQueriesRequest : IRequest<List<GetReporterWorkerByCompanyIdQueriesResponse>>
    {
        public int CompanyId { get; set; }


    }
}
