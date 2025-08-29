using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissions.Command.Delete
{
    public class DeleteTeamMissionsCommandHandler : IRequestHandler<DeleteTeamMissionsCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTeamMissionsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTeamMissionsCommandRequest request, CancellationToken cancellationToken)
        {
            var getTeamMissions = await _unitOfWork.GetReadRepository<Domain.Entity.TeamMissions>()
                .GetByExpression(false, x => x.TeamId == request.TeamId).FirstOrDefaultAsync();
            await _unitOfWork.GetWriteRepository<Domain.Entity.TeamMissions>().DeleteAsync(getTeamMissions);
            await _unitOfWork.SaveAsync();
        }
    }
}
