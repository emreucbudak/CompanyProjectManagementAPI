using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.AllReports.Queries.GetAll
{
    public class GetAllReportsQueriesRequestHandler : IRequestHandler<GetAllReportsQueriesRequest, List<GetAllReportsQueriesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllReportsQueriesRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllReportsQueriesResponse>> Handle(GetAllReportsQueriesRequest request, CancellationToken cancellationToken)
        {
            var getAllReports = await _unitOfWork.GetReadRepository<Domain.Entity.AllReports>()
                .GetAllAsync(trackChanges: false, predicate: x => x.ReporterWorker.CompanyId == request.CompanyId,include:q=> q.Include(x=> x.ReporterWorker).ThenInclude(x=> x.User).Include(x=> x.Worker).ThenInclude(x=> x.User));
            return getAllReports.Select(report => new GetAllReportsQueriesResponse()
            {
                ReportDescription = report.ReportDescription,
                ReportTitle = report.ReportTitle,
                ReporterWorkerName = report.ReporterWorker.User.Name,
                WorkerName = report.Worker is not null ? report.Worker.User.Name : "Çalışana atama yapılmadı",
                MissionStatusName = report.MissionStatus.StatusName,
                ReportId = report.Id

            }).ToList();
        }
    }
}