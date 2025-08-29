using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.Team.Command.Create
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTeamCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateTeamCommandRequest request, CancellationToken cancellationToken)
        {
            var team = new Domain.Entity.Team
            {
                TeamName = request.TeamName,
                CompanyId = request.CompanyId,
                IsDeleted = false,
                Workers = request.Workers,

            };
            await _unitOfWork.GetWriteRepository<Domain.Entity.Team>()
                .AddAsync(team);
            await _unitOfWork.SaveAsync();
        }
    }
}