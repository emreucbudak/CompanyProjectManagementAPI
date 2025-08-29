using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.AllReports.Command.Update
{
    public class UpdateReportsCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string ReportTitle { get; set; }
        public string ReportDescription { get; set; }
        public int MissionStatusId { get; set; }
    }
}
