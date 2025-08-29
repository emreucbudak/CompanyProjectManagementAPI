using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.ReporterWorker.Command.Delete
{
    public class DeleteReporterWorkerCommandRequestHandler : IRequestHandler<DeleteReporterWorkerCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteReporterWorkerCommandRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteReporterWorkerCommandRequest request, CancellationToken cancellationToken)
        {
            var getReporterWorker = await _unitOfWork.GetReadRepository<Domain.Entity.ReporterWorker>()
                .GetByExpression(trackChanges:false, x=> x.Id == request.reporterWorkerId).FirstOrDefaultAsync();
            await _unitOfWork.GetWriteRepository<Domain.Entity.ReporterWorker>()
                .DeleteAsync(getReporterWorker);
            await _unitOfWork.SaveAsync();
        }
    }
}
