using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Common;

namespace TaskProjectManagementApi.Domain.Entity
{
    public class AllReports : BaseEntity
    {
        public AllReports()
        {
        }

        public AllReports(string reportTitle, string reportDescription, int reporterWorkerId, int? workerId, int missionStatusId)
        {
            ReportTitle = reportTitle;
            ReportDescription = reportDescription;
            ReporterWorkerId = reporterWorkerId;
            WorkerId = workerId;
            MissionStatusId = missionStatusId;
        }

        public string ReportTitle { get; set; }
        public string ReportDescription { get; set; }
        public int ReporterWorkerId { get; set; }
        public ReporterWorker ReporterWorker { get; set; }
        public int? WorkerId { get; set; }
        public Worker? Worker { get; set; }
        public int MissionStatusId { get; set; }    
        public MissionStatus MissionStatus { get; set; }
        public ICollection<ReportAnswer> Answers { get; set; } = new List<ReportAnswer>();



    }
}
