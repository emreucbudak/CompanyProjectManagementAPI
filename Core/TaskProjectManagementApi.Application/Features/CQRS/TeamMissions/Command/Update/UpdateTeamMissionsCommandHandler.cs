using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissions.Command.Update
{
    public class UpdateTeamMissionsCommandHandler : IRequestHandler<UpdateTeamMissionsCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTeamMissionsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  async Task Handle(UpdateTeamMissionsCommandRequest request, CancellationToken cancellationToken)
        {
            var getTeamMissions = await _unitOfWork.GetReadRepository<Domain.Entity.TeamMissions>()
                .GetByExpression(false, x => x.TeamId == request.TeamId).FirstOrDefaultAsync();
            getTeamMissions.IsDeleted = true;
            await _unitOfWork.GetWriteRepository<Domain.Entity.TeamMissions>().UpdateAsync(getTeamMissions);
            await _unitOfWork.SaveAsync();
        }
    }
}
