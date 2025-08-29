using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissionsAnswer.Command.Create
{
    public class CreateTeamMissionsAnswerCommandHandler : IRequestHandler<CreateTeamMissionsAnswerCommandRequest>
    {
        private readonly IUnitOfWork unit;

        public CreateTeamMissionsAnswerCommandHandler(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public async Task Handle(CreateTeamMissionsAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var workerName = await unit.GetReadRepository<Domain.Entity.Worker>()
             .GetByExpression(trackChanges: false,
                              expression: x => x.Id == request.WorkerId).FirstOrDefaultAsync();
            var teamMissionsAnswer = new Domain.Entity.TeamMissionsAnswer
            {
                WorkerName = workerName.User.Name,
                TeamMissionsId = request.TeamMissionsId,
                Answer = request.Answer
            };
            await unit.GetWriteRepository<Domain.Entity.TeamMissionsAnswer>().AddAsync(teamMissionsAnswer);
            await unit.SaveAsync();
        }
    }
}
