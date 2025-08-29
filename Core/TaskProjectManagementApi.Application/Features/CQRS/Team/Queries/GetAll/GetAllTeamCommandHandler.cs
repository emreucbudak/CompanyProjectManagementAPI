using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.Team.Queries.GetAll
{
    public class GetAllTeamCommandHandler : IRequestHandler<GetAllTeamCommandRequest, List<GetAllTeamCommandResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTeamCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllTeamCommandResponse>> Handle(GetAllTeamCommandRequest request, CancellationToken cancellationToken)
        {
            var getAllTeams = await _unitOfWork.GetReadRepository<Domain.Entity.Team>()
                .GetAllAsync(trackChanges: false
                             , predicate: x => x.CompanyId == request.CompanyId);
            return getAllTeams.Select(team => new GetAllTeamCommandResponse()
            {
                TeamName = team.TeamName,
                WorkerName = team.Workers.Select(w => w.User.Name).ToList(),

            }).ToList();
        }
    }
}
