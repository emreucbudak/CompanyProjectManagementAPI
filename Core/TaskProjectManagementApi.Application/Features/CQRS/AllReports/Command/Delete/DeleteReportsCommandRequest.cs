using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.AllReports.Command.Delete
{
    public class DeleteReportsCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}
