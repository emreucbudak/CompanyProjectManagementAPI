using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.AllReports.Queries.GetAll
{
    public class GetAllReportsQueriesRequest : IRequest<List<GetAllReportsQueriesResponse>>
    {
        public int CompanyId { get; set; }
    }
}
