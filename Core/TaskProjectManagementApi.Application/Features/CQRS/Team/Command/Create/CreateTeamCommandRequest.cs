using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Application.Features.CQRS.Team.Command.Create
{
    public class CreateTeamCommandRequest : IRequest
    {
        public string TeamName { get; set; }
        public ICollection<Worker> Workers { get; set; }

        public int CompanyId { get; set; }
    }
}
