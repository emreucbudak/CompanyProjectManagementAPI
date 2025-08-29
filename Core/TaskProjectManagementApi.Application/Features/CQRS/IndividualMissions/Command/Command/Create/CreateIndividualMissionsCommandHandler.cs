using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissions.Command.Command.Create
{
    public class CreateIndividualMissionsCommandHandler : IRequestHandler<CreateIndividualMissionsCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateIndividualMissionsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateIndividualMissionsCreateRequest request, CancellationToken cancellationToken)
        {
            var CreateIndividualMissions = new Domain.Entity.IndividualMissions()
            {
                WorkerId = request.WorkerId,
                MissionTitle = request.MissionTitle,
                MissionDescription = request.MissionDescription,
                MissionStatusId = request.MissionStatusId
            };
            await _unitOfWork.GetWriteRepository<Domain.Entity.IndividualMissions>().AddAsync(CreateIndividualMissions);
            await _unitOfWork.SaveAsync();
        }
    }
}
