using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissionsAnswer.Queries.GetById
{
    public class GetIndividualMissionsAnswerByIdCommandHandler : IRequestHandler<GetIndividualMissionsAnswerByIdCommandRequest, GetIndividualMissionsAnswerByIdCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetIndividualMissionsAnswerByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GetIndividualMissionsAnswerByIdCommandResponse> Handle(GetIndividualMissionsAnswerByIdCommandRequest request, CancellationToken cancellationToken)
        {
            var gts = await unitOfWork
    .GetReadRepository<TaskProjectManagementApi.Domain.Entity.IndividualMissionsAnswer>()
    .GetAllAsync(
        trackChanges: false,
        predicate: x => x.IndividualMissionsId == request.IndividualMissionsId,
        include: x => x
            .Include(y => y.IndividualMissions)
                .ThenInclude(z => z.Worker)                
            .Include(y => y.IndividualMissions)
                .ThenInclude(z => z.MissionStatus)         
            .Include(y => y.AnswerStatus)               
    );

            var t = gts.FirstOrDefault();
            return new GetIndividualMissionsAnswerByIdCommandResponse()
            {
                MissionDescription = t.IndividualMissions.MissionDescription,
                Answer = t.Answer,
                AnswerStatus = t.AnswerStatus.StatusName,
                MissionStatus = t.IndividualMissions.MissionStatus.StatusName,
                MissionTitle = t.IndividualMissions.MissionTitle,
                WorkerName = t.IndividualMissions.Worker.User.Name
            };

        }
    }
}
