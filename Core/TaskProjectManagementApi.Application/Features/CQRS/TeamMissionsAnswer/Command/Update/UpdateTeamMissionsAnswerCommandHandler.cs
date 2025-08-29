using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissionsAnswer.Command.Update
{
    public class UpdateTeamMissionsAnswerCommandHandler : IRequestHandler<UpdateTeamMissionsAnswerCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTeamMissionsAnswerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateTeamMissionsAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var getTeamMissionsAnswer = await _unitOfWork.GetReadRepository<Domain.Entity.TeamMissionsAnswer>()
                .GetByExpression(false, x => x.Id == request.TeamMissionsAnswerId).FirstOrDefaultAsync();
           getTeamMissionsAnswer.AnswerStatusId = request.statusId;
            await _unitOfWork.GetWriteRepository<Domain.Entity.TeamMissionsAnswer>().UpdateAsync(getTeamMissionsAnswer);
            await _unitOfWork.SaveAsync();
        }
    }
}
