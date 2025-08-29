using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.ReportAnswer.Command.Create
{
    public class CreateReportAnswerCommandRequest : IRequest
    {
        public string AnswerText { get; set; }
        public int AllReportsId { get; set; }
    }
}
