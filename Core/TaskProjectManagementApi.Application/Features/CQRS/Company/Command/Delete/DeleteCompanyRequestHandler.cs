using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.Company.Command.Delete
{
    public class DeleteCompanyRequestHandler : IRequestHandler<DeleteCompanyRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCompanyRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCompanyRequest request, CancellationToken cancellationToken)
        {
            var ds = await _unitOfWork.GetReadRepository<Domain.Entity.Company>()
                .GetByExpression(true, x => x.Id == request.Id).FirstOrDefaultAsync();
            await _unitOfWork.GetWriteRepository<Domain.Entity.Company>().DeleteAsync(ds);
            await _unitOfWork.SaveAsync();
        }
    }
}
