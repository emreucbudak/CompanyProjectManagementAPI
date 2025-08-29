using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.AllReports.Queries.GetAllByIdWorker
{
    public class GetAllReportsByIdForWorkerQueriesHandler : IRequestHandler<GetAllReportsByIdForWorkerQueriesRequest, List<GetAllReportsByIdForWorkerQueriesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllReportsByIdForWorkerQueriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllReportsByIdForWorkerQueriesResponse>> Handle(GetAllReportsByIdForWorkerQueriesRequest request, CancellationToken cancellationToken)
        {
            var getAllByWorkerId = await _unitOfWork.GetReadRepository<TaskProjectManagementApi.Domain.Entity.AllReports>().GetAllAsync(
                predicate: x => x.WorkerId == request.WorkerId,
                include: x => x.Include(y => y.ReporterWorker).ThenInclude(y => y.User).Include(y => y.MissionStatus)
            );
            return getAllByWorkerId.Select(x => new GetAllReportsByIdForWorkerQueriesResponse()
            {
                ReportDescription = x.ReportDescription,
                MissionStatusName = x.MissionStatus.StatusName,
                ReportTitle = x.ReportTitle,
                ReporterWorkerName = x.ReporterWorker.User.Name ?? "Atama Yapılmadı",
                ReportId = x.Id
            }).ToList();
        }
    }
}
