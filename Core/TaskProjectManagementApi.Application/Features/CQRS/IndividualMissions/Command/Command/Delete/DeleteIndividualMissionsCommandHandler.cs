using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissions.Command.Command.Delete
{
    public class DeleteIndividualMissionsCommandHandler : IRequestHandler<DeleteIndividualMissionsCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteIndividualMissionsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteIndividualMissionsCommandRequest request, CancellationToken cancellationToken)
        {
            var getIndividualMissions = await _unitOfWork
                .GetReadRepository<Domain.Entity.IndividualMissions>()
                .GetByExpression(trackChanges:false,expression: x=> x.Id == request.Id).FirstOrDefaultAsync();
            await _unitOfWork
                .GetWriteRepository<Domain.Entity.IndividualMissions>()
                .DeleteAsync(getIndividualMissions);
            await _unitOfWork.SaveAsync();
        }
    }
}
