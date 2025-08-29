using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.ReportAnswer.Queries.GetAllByIdForAll
{
    public class GetAllByIdForAllReportAnswerQueriesResponse
    {
        public string AnswerText { get; set; }
        public DateTime AnswerDate { get; set; }
        public string ReportTitle { get; set; }
        public string ReportDescription { get; set; }
    }
}
