using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.ReportAnswer.Command.Delete
{
    public class DeleteReportAnswerCommandHandler : IRequestHandler<DeleteReportAnswerCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteReportAnswerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteReportAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var getOne = await _unitOfWork.GetReadRepository<Domain.Entity.ReportAnswer>().GetByExpression(trackChanges:false,expression: x=> x.Id == request.Id).FirstOrDefaultAsync();
            await _unitOfWork.GetWriteRepository<Domain.Entity.ReportAnswer>().DeleteAsync(getOne);
            await _unitOfWork.SaveAsync();
        }
    }
}
