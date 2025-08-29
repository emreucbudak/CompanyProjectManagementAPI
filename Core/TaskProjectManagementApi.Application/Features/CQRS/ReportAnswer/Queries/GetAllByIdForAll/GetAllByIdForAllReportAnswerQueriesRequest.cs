using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.ReportAnswer.Queries.GetAllByIdForAll
{
    public class GetAllByIdForAllReportAnswerQueriesRequest : IRequest<GetAllByIdForAllReportAnswerQueriesResponse>
    {
        public int ReportId { get; set; }
    }
}
