using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.ReporterWorker.Queries.GetByCompanyId
{
    public class GetReporterWorkerByCompanyIdQueriesHandler : IRequestHandler<GetReporterWorkerByCompanyIdQueriesRequest, List<GetReporterWorkerByCompanyIdQueriesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetReporterWorkerByCompanyIdQueriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetReporterWorkerByCompanyIdQueriesResponse>> Handle(GetReporterWorkerByCompanyIdQueriesRequest request, CancellationToken cancellationToken)
        {
            var getReporterWorkerByCompanyId = await _unitOfWork.GetReadRepository<Domain.Entity.ReporterWorker>()
                .GetAllAsync(trackChanges: false, 
                             include: q => q.Include(x => x.Company).Include(x=> x.User), 
                             predicate: y => y.CompanyId == request.CompanyId);
            return getReporterWorkerByCompanyId.Select(reporterWorker => new GetReporterWorkerByCompanyIdQueriesResponse()
            {

                Email = reporterWorker.User.Email,
                Name = reporterWorker.User.Name,
                Password = reporterWorker.User.PasswordHash
            }).ToList();
        }
    }
}
