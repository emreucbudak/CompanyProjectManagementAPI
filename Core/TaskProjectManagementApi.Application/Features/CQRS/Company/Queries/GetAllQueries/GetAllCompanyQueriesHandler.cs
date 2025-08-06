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
                    include: x => x.Include(c => c.Workers),
                    trackChanges: false,
                    ordered: c => c.OrderBy(c => c.Id)
                );

            var responseList = companies.Select(company => new CompanyWithWorkersResponse
            {
                CompanyName = company.CompanyName,
                IsDeleted = company.IsDeleted,
                Workers = company.Workers?.Select(worker => new WorkerDto
                {
                    Name = worker.Name,
                    Email = worker.Email,
                    // Password gönderme
                    IsAvailable = worker.IsAvailable,
                    IsLeaved = worker.IsLeaved
                }).ToList() ?? new List<WorkerDto>()
            }).ToList();

            return responseList;
        }

    }
}
