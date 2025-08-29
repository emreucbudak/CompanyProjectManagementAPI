using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.Worker.Command.Delete
{
    public class DeleteWorkerCommandHandler : IRequestHandler<DeleteWorkerCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteWorkerCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteWorkerCommandRequest request, CancellationToken cancellationToken)
        {
            var getForDelete = await unitOfWork.GetReadRepository<Domain.Entity.Worker>().GetByExpression(trackChanges:false,expression:x=> x.Id == request.WorkerId).FirstOrDefaultAsync();
            await unitOfWork.GetWriteRepository<Domain.Entity.Worker>().DeleteAsync(getForDelete);
            await unitOfWork.SaveAsync();
        }
    }
}
