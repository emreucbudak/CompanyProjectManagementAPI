using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissionsAnswer.Command.Create
{
    public class CreateIndividualMissionsAnswerCommandHandler : IRequestHandler<CreateIndividualMissionsAnswerCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateIndividualMissionsAnswerCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateIndividualMissionsAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            TaskProjectManagementApi.Domain.Entity.IndividualMissionsAnswer IndividualMissionsForAdded = new()
            {
                IsDeleted = false,
                Answer = request.Answer,
                AnswerStatusId = request.AnswerStatusId,
                IndividualMissionsId = request.IndividualMissionId,

            };
            await unitOfWork.GetWriteRepository<TaskProjectManagementApi.Domain.Entity.IndividualMissionsAnswer>().AddAsync(IndividualMissionsForAdded);
            await unitOfWork.SaveAsync();
        }
    }
}
