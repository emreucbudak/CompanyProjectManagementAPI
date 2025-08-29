using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.Team.Queries.GetByWorkerId
{

    public class GetTeamByWorkerIdQueriesHandler : IRequestHandler<GetTeamByWorkerIdQueriesRequest, GetTeamByWorkerIdQueriesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTeamByWorkerIdQueriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetTeamByWorkerIdQueriesResponse> Handle(GetTeamByWorkerIdQueriesRequest request, CancellationToken cancellationToken)
        {
            var gts = await _unitOfWork.GetReadRepository<Domain.Entity.Team>().GetByExpression(trackChanges: false, expression: x => x.Workers.Any(x=> x.Id == request.WorkerId),inc:x=> x.Include(y=> y.Company)).FirstOrDefaultAsync();
            return new GetTeamByWorkerIdQueriesResponse
            {
                TeamName = gts.TeamName
            };
        }
    }
}
