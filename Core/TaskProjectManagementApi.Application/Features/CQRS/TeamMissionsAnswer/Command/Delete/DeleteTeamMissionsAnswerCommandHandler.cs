using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissionsAnswer.Command.Delete
{
    public class DeleteTeamMissionsAnswerCommandHandler : IRequestHandler<DeleteTeamMissionsAnswerCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTeamMissionsAnswerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTeamMissionsAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var getTeamMissionsAnswer = await _unitOfWork.GetReadRepository<Domain.Entity.TeamMissionsAnswer>()
                .GetByExpression(false, x => x.Id == request.TeamMissionsAnswerId).FirstOrDefaultAsync();
            await _unitOfWork.GetWriteRepository<Domain.Entity.TeamMissionsAnswer>().DeleteAsync(getTeamMissionsAnswer);
            await _unitOfWork.SaveAsync();
        }
    }
}
