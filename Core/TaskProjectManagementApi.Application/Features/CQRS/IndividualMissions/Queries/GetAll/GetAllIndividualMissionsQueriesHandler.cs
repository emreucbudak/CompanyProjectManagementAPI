using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissions.Queries.GetAll
{
    public class GetAllIndividualMissionsQueriesHandler : IRequestHandler<GetAllIndividualMissionsQueriesRequest, List<GetAllIndividualMissionsQueriesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllIndividualMissionsQueriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllIndividualMissionsQueriesResponse>> Handle(GetAllIndividualMissionsQueriesRequest request, CancellationToken cancellationToken)
        {
              var getAllIndividualMissions = await _unitOfWork.GetReadRepository<Domain.Entity.IndividualMissions>()
                .GetAllAsync(trackChanges: false, include: q => q.Include(x=> x.Worker ).ThenInclude(x=> x.User),predicate: y=> y.Worker.CompanyId == request.CompanyId);
            return getAllIndividualMissions.Select(mission => new GetAllIndividualMissionsQueriesResponse()
            {
                MissionDescription = mission.MissionDescription,
                StatusName = mission.MissionStatus.StatusName,
                MissionTitle = mission.MissionTitle,
                WorkerName = mission.Worker.User.Name,
            }).ToList();
        }
    }
}
