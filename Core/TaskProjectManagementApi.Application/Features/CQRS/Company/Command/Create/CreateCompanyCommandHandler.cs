using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Application.Features.CQRS.Company.Command.Create
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
        {
            var ds = new TaskProjectManagementApi.Domain.Entity.Company()
            {
                IsDeleted = false,
                CompanyName = request.CompanyName,
                Workers = request.Workers
            };
            await _unitOfWork.GetWriteRepository<TaskProjectManagementApi.Domain.Entity.Company>().AddAsync(ds);
            await _unitOfWork.SaveAsync();
        }
    }
}
