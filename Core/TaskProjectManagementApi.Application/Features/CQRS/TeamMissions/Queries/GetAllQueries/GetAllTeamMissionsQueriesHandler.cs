using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissions.Queries.GetAllQueries
{
    public class GetAllTeamMissionsQueriesHandler : IRequestHandler<GetAllTeamMissionsQueriesRequest, List<GetAllTeamMissionsQueriesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTeamMissionsQueriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllTeamMissionsQueriesResponse>> Handle(GetAllTeamMissionsQueriesRequest request, CancellationToken cancellationToken)
        {
            var getAllTeamMissions = await _unitOfWork.GetReadRepository<Domain.Entity.TeamMissions>().GetAllAsync(trackChanges: false, predicate: x => x.Team.CompanyId == request.CompanyId, include:q => q.Include(x=> x.Team).Include(c=> c.MissionStatus));
            return getAllTeamMissions.Select(x => new GetAllTeamMissionsQueriesResponse
            {
                MissionTitle = x.MissionTitle,
                MissionDescription = x.MissionDescription,
                StatusName = x.MissionStatus.StatusName,
                TeamName = x.Team.TeamName,

            }).ToList();
        }
    }
}
