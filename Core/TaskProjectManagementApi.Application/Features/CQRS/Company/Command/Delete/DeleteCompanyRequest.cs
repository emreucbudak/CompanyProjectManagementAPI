using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.Company.Command.Delete
{
    public class DeleteCompanyRequest : IRequest
    {
        public int Id { get; set; }

    }
}
