using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.AllReports.Queries.GetAllByIdWorker
{
    public class GetAllReportsByIdForWorkerQueriesResponse
    {
        public string ReportTitle { get; set; }
        public string ReportDescription { get; set; }
        public string ReporterWorkerName { get; set; }
        public string MissionStatusName { get; set; }
        public int ReportId { get; set; }
    }
}
