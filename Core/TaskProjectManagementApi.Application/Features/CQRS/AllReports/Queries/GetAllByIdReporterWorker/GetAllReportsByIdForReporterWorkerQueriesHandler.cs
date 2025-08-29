using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.AllReports.Queries.GetAllByIdReporterWorker
{
    public class GetAllReportsByIdForReporterWorkerQueriesHandler : IRequestHandler<GetAllReportsByIdForReporterWorkerQueriesRequest, List<GetAllReportsByIdForReporterWorkerQueriesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllReportsByIdForReporterWorkerQueriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllReportsByIdForReporterWorkerQueriesResponse>> Handle(GetAllReportsByIdForReporterWorkerQueriesRequest request, CancellationToken cancellationToken)
        {
            var allReports = await _unitOfWork.GetReadRepository<TaskProjectManagementApi.Domain.Entity.AllReports>().GetAllAsync(
                predicate: x => x.ReporterWorkerId == request.ReporterWorkerId,
                include: x=> x.Include(y=> y.Worker).ThenInclude(y=> y.User).Include(y => y.MissionStatus)
                );
            return allReports.Select(x=> new GetAllReportsByIdForReporterWorkerQueriesResponse()
            {
                ReportDescription = x.ReportDescription,
                MissionStatusName = x.MissionStatus.StatusName,
                ReportTitle = x.ReportTitle,
                WorkerName = x.Worker.User.Name ?? "Atama Yapılmadı",
                ReportId = x.Id
            }).ToList();
        }
    }
}
