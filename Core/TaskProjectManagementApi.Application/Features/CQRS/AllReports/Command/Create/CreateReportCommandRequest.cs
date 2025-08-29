using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.AllReports.Command.Create
{
    public class CreateReportCommandRequest : IRequest
    {
        public string ReportTitle { get; set; }
        public string ReportDescription { get; set; }
        public int ReporterWorkerId { get; set; }
        public int? WorkerId { get; set; }
        public int MissionStatusId { get; set; }
    }
}
