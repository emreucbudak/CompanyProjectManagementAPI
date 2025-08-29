using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.IndividualMissions.Queries.GetAllById
{
    public class GetAllIndividualMissionsByIdQueriesHandler : IRequestHandler<GetAllIndividualMissionsByIdQueriesRequest, List<GetAllIndividualMissionsQueriesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllIndividualMissionsByIdQueriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllIndividualMissionsQueriesResponse>> Handle(GetAllIndividualMissionsByIdQueriesRequest request, CancellationToken cancellationToken)
        {
            var getAllIndividualForPerson = await _unitOfWork.GetReadRepository<Domain.Entity.IndividualMissions>()
                .GetAllAsync(trackChanges: false, 
                             include: q => q.Include(x => x.Worker)
                                            .Include(x => x.MissionStatus),
                             predicate: y => y.WorkerId == request.WorkerId);
            return getAllIndividualForPerson.Select(mission => new GetAllIndividualMissionsQueriesResponse() { 
                MissionDescription = mission.MissionDescription,
                MissionTitle = mission.MissionTitle,
                StatusName = mission.MissionStatus.StatusName
            }).ToList();
        }
    }
}
