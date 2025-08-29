using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissionsAnswer.Command.Delete
{
    public class DeleteIndividualMissionsAnswerCommandHandler : IRequestHandler<DeleteIndividualMissionsAnswerCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteIndividualMissionsAnswerCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteIndividualMissionsAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var rts = await unitOfWork.GetReadRepository<TaskProjectManagementApi.Domain.Entity.IndividualMissionsAnswer>().GetByExpression(trackChanges: false, expression: x => x.Id == request.Id).FirstOrDefaultAsync();
            await unitOfWork.GetWriteRepository<TaskProjectManagementApi.Domain.Entity.IndividualMissionsAnswer>().DeleteAsync(rts);
            await unitOfWork.SaveAsync();
        }
    }
}
