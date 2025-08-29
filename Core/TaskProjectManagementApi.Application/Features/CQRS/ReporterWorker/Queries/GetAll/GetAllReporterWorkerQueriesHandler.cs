using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.ReporterWorker.Queries.GetAll
{
    public class GetAllReporterWorkerQueriesHandler : IRequestHandler<GetAllReporterWorkerQueriesRequest, List<GetAllReporterWorkerQueriesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllReporterWorkerQueriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllReporterWorkerQueriesResponse>> Handle(GetAllReporterWorkerQueriesRequest request, CancellationToken cancellationToken)
        {
            var getAllReporterWorker = await _unitOfWork.GetReadRepository<Domain.Entity.ReporterWorker>()
                .GetAllAsync(trackChanges:false,include: q => q.Include(x=> x.Company).Include(x=> x.User));
            return getAllReporterWorker.Select(reporterWorker => new GetAllReporterWorkerQueriesResponse()
            {
                CompanyName = reporterWorker.Company.CompanyName,
                Email = reporterWorker.User.Email,
                Name = reporterWorker.User.Name,
                Password = reporterWorker.User.PasswordHash
            }).ToList();


        }
    }
}
