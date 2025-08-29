using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.AllReports.Command.Delete
{
    public class DeleteReportsCommandHandler : IRequestHandler<DeleteReportsCommandRequest>
    {
        private readonly IUnitOfWork _reportRepository;

        public DeleteReportsCommandHandler(IUnitOfWork reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task Handle(DeleteReportsCommandRequest request, CancellationToken cancellationToken)
        {
            var rpt = await _reportRepository.GetReadRepository<Domain.Entity.AllReports>().GetByExpression(true, x=> x.Id == request.Id).FirstOrDefaultAsync();
            await _reportRepository.GetWriteRepository<Domain.Entity.AllReports>().DeleteAsync(rpt);
            await _reportRepository.SaveAsync();
        }
    }
}
