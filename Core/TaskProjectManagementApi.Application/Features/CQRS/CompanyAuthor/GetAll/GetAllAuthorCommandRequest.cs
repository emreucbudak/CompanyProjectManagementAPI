using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.CompanyAuthor.GetAll
{
    public class GetAllAuthorCommandRequest : IRequest<List<GetAllAuthorCommandResponse>>
    {
        public int CompanyId { get; set; }

    }
}
