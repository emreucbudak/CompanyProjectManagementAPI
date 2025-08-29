using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.Team.Command.Delete
{
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTeamCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTeamCommandRequest request, CancellationToken cancellationToken)
        {
            var getTeam = await _unitOfWork.GetReadRepository<Domain.Entity.Team>()
                .GetByExpression(trackChanges: false, x => x.Id == request.Id).FirstOrDefaultAsync();
            getTeam.IsDeleted = true;   
            await _unitOfWork.GetWriteRepository<Domain.Entity.Team>()
                .UpdateAsync(getTeam);
            await _unitOfWork.SaveAsync();
        }
    }
}
