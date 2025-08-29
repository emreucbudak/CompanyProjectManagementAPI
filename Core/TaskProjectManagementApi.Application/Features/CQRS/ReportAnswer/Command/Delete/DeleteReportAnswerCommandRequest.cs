using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.ReportAnswer.Command.Delete
{
    public class DeleteReportAnswerCommandRequest  : IRequest
    {
        public int Id { get; set; }
    }
}
