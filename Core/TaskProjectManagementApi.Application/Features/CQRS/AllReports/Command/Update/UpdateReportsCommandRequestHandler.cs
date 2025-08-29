using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.AllReports.Command.Update
{
    public class UpdateReportsCommandRequestHandler : IRequestHandler<UpdateReportsCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateReportsCommandRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateReportsCommandRequest request, CancellationToken cancellationToken)
        {
            var getReport = await unitOfWork.GetReadRepository<Domain.Entity.AllReports>()
                .GetByExpression(true, x => x.Id == request.Id).FirstOrDefaultAsync();
            getReport.ReportTitle = request.ReportTitle;
            getReport.ReportDescription = request.ReportDescription;
            getReport.MissionStatusId = request.MissionStatusId;
            await unitOfWork.GetWriteRepository<Domain.Entity.AllReports>().UpdateAsync(getReport);
            await unitOfWork.SaveAsync();
        }
    }
}
