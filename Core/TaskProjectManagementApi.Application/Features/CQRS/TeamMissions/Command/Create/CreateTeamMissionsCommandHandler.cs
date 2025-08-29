using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissions.Command.Create
{
    public class CreateTeamMissionsCommandHandler : IRequestHandler<CreateTeamMissionsCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTeamMissionsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateTeamMissionsCommandRequest request, CancellationToken cancellationToken)
        {
            var teamMission = new Domain.Entity.TeamMissions
            {
                MissionTitle = request.MissionTitle,
                MissionDescription = request.MissionDescription,
                MissionStatusId = request.MissionStatusId,
                TeamId = request.TeamId
            };
            await _unitOfWork.GetWriteRepository<Domain.Entity.TeamMissions>().AddAsync(teamMission);
            await _unitOfWork.SaveAsync();
        }
    }
}
