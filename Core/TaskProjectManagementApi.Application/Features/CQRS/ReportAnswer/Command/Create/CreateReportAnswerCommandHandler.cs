using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.ReportAnswer.Command.Create
{
    public class CreateReportAnswerCommandHandler : IRequestHandler<CreateReportAnswerCommandRequest>
    {
        private readonly IUnitOfWork _reportAnswerRepository;

        public CreateReportAnswerCommandHandler(IUnitOfWork reportAnswerRepository)
        {
            _reportAnswerRepository = reportAnswerRepository;
        }

        public async Task Handle(CreateReportAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var createReportAnswer = new Domain.Entity.ReportAnswer()
            {
                AnswerText = request.AnswerText,
                AllReportsId = request.AllReportsId
            };
            await _reportAnswerRepository.GetWriteRepository<Domain.Entity.ReportAnswer>().AddAsync(createReportAnswer);
            await _reportAnswerRepository.SaveAsync();
        }
    }
}
