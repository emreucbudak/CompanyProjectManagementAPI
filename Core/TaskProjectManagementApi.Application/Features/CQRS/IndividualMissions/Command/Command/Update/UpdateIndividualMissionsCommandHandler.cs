using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissions.Command.Command.Update
{
    public class UpdateIndividualMissionsCommandHandler : IRequestHandler<UpdateIndividualMissionsCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateIndividualMissionsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateIndividualMissionsCommandRequest request, CancellationToken cancellationToken)
        {
            var getIndividualMissions = await _unitOfWork
                .GetReadRepository<Domain.Entity.IndividualMissions>()
                .GetByExpression(trackChanges: true, expression: x => x.Id == request.Id).FirstOrDefaultAsync();
            getIndividualMissions.MissionTitle = request.MissionTitle;
            getIndividualMissions.MissionDescription = request.MissionDescription;
            await _unitOfWork.GetWriteRepository<Domain.Entity.IndividualMissions>().UpdateAsync(getIndividualMissions);
            await _unitOfWork.SaveAsync();
        }
    }
}
