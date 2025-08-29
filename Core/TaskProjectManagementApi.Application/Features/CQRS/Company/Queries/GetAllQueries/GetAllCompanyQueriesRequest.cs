using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.Company.Queries.GetAllQueries
{
    public class GetAllCompanyQueriesRequest : IRequest<IList<CompanyWithWorkersResponse>>
    {
        public int CompanyId { get; set; }
    }
}
