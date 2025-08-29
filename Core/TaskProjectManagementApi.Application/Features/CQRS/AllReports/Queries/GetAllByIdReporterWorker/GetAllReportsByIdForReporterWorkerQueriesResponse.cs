using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.AllReports.Queries.GetAllByIdReporterWorker
{
    public class GetAllReportsByIdForReporterWorkerQueriesResponse
    {
        public string ReportTitle { get; set; }
        public string ReportDescription { get; set; }
        public string WorkerName { get; set; }
        public string MissionStatusName { get; set; }
        public int ReportId { get; set; }
    }
}
