using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Application.Features.CQRS.Team.Queries.GetAll
{
    public class GetAllTeamCommandResponse
    {
        public string TeamName { get; set; }
        public IList<string> WorkerName { get; set; }
   



    }
}
