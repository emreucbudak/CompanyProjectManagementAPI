using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.Worker.Command.Update
{
    public class UpdateWorkerCommandRequest : IRequest
    {

        public string NewPassword { get; set; }
        public string? Email { get; set; }

        public string OldPassword { get; set; }
    }
}
