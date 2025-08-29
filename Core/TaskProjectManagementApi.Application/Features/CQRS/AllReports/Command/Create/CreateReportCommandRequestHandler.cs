using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.AllReports.Command.Create
{
    public class CreateReportCommandRequestHandler : IRequestHandler<CreateReportCommandRequest>
    {
        private readonly IUnitOfWork _reportRepository;

        public CreateReportCommandRequestHandler(IUnitOfWork reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task Handle(CreateReportCommandRequest request, CancellationToken cancellationToken)
        {
            var newReport = new Domain.Entity.AllReports
            {
                ReportTitle = request.ReportTitle,
                ReportDescription = request.ReportDescription,
                ReporterWorkerId = request.ReporterWorkerId,
                WorkerId = request.WorkerId,
                MissionStatusId = request.MissionStatusId
            };
            await _reportRepository.GetWriteRepository<Domain.Entity.AllReports>().AddAsync(newReport);
            await _reportRepository.SaveAsync();
        }
    }
}
