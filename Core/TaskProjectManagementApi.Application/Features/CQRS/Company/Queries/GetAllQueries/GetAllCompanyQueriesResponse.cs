using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.Company.Queries.GetAllQueries
{
    public class WorkerDto
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public bool IsAvailable { get; set; }
        public bool IsLeaved { get; set; }
    }

    public class CompanyWithWorkersResponse
    {
        public string CompanyName { get; set; }
        public bool IsDeleted { get; set; }
        public List<WorkerDto> Workers { get; set; }
    }
}
