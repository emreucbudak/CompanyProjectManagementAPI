using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Application.Features.CQRS.CompanyAuthor.GetAll
{
    public class GetAllAuthorCommandRequestHandler : IRequestHandler<GetAllAuthorCommandRequest, List<GetAllAuthorCommandResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAuthorCommandRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllAuthorCommandResponse>> Handle(GetAllAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var ds = await _unitOfWork.GetReadRepository<Domain.Entity.CompanyAuthor>()
                .GetAllAsync(
                    predicate: x => x.CompanyId == request.CompanyId,
                    include: x => x.Include(x => x.Company).Include(x=>x.User),
                    trackChanges: false,
                    ordered: x => x.OrderBy(x => x.User.Name));
            return ds.Select(x => new GetAllAuthorCommandResponse()
            {
                CompanyName = x.Company.CompanyName,
                Email = x.User.Email,
                Name = x.User.Name
            }).ToList();
        }
    }
}
