using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.TeamMissionsAnswer.Queries
{
    public class GetAllTeamMissionsAnswerQueriesHandler : IRequestHandler<GetAllTeamMissionsAnswerQueriesRequest, List<GetAllTeamMissionsAnswerQueriesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTeamMissionsAnswerQueriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllTeamMissionsAnswerQueriesResponse>> Handle(GetAllTeamMissionsAnswerQueriesRequest request, CancellationToken cancellationToken)
        {
            var getAllTeamMissionsAnswer = await _unitOfWork.GetReadRepository<Domain.Entity.TeamMissionsAnswer>()
                .GetAllAsync(trackChanges: false, predicate: x => x.TeamMissions.TeamId == request.TeamId, include: q => q.Include(y=> y.AnswerStatus).Include(z=> z.TeamMissions).ThenInclude(t => t.Team));
            return getAllTeamMissionsAnswer.Select(x => new GetAllTeamMissionsAnswerQueriesResponse()
            {
                Answer = x.Answer,
                MissionName = x.TeamMissions.MissionTitle,
                StatusName = x.AnswerStatus.StatusName,
                TeamName = x.TeamMissions.Team.TeamName,
                WorkerName = x.TeamMissions.Team.Workers.Select(w => w.User.Name).ToList()
            }).ToList();
        }
    }
}
