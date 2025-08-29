using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.Company.Queries.GetAllQueries
{
    public class GetAllCompanyQueriesHandler : IRequestHandler<GetAllCompanyQueriesRequest, IList<CompanyWithWorkersResponse>>
    {
        private readonly IUnitOfWork _readRepository;

        public GetAllCompanyQueriesHandler(IUnitOfWork readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IList<CompanyWithWorkersResponse>> Handle(GetAllCompanyQueriesRequest request, CancellationToken cancellationToken)
        {
            var companies = await _readRepository.GetReadRepository<Domain.Entity.Company>()
                .GetAllAsync(
                    trackChanges: false,
                    ordered: c => c.OrderBy(c => c.Id)
                );

           var getAllWorkers = await _readRepository.GetReadRepository<Domain.Entity.Worker>()
                .GetAllAsync(
                    trackChanges: false,
                    predicate: y => y.CompanyId == request.CompanyId
                );
            List<WorkerDto> workerDtos = getAllWorkers.Select(worker => new WorkerDto
            {
                IsAvailable = worker.IsAvailable,
                Name = worker.User.Name,
                Email = worker.User.Email,
                IsLeaved = worker.IsLeaved
            }).ToList();
            var responseList = companies.Select(company => new CompanyWithWorkersResponse
            {
                CompanyName = company.CompanyName,
                IsDeleted = company.IsDeleted,
                Workers = workerDtos

            }).ToList();
            

            return responseList;
        }

    }
}
