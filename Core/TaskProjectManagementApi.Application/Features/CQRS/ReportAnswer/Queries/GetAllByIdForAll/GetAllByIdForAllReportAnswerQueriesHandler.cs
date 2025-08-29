using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;

namespace TaskProjectManagementApi.Application.Features.CQRS.ReportAnswer.Queries.GetAllByIdForAll
{
    public class GetAllByIdForAllReportAnswerQueriesHandler : IRequestHandler<GetAllByIdForAllReportAnswerQueriesRequest, GetAllByIdForAllReportAnswerQueriesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllByIdForAllReportAnswerQueriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAllByIdForAllReportAnswerQueriesResponse> Handle(GetAllByIdForAllReportAnswerQueriesRequest request, CancellationToken cancellationToken)
        {
            var getAllByReportIdForAll = await _unitOfWork.GetReadRepository<Domain.Entity.ReportAnswer>().GetByExpression(trackChanges:false,expression: x=> x.AllReportsId == request.ReportId).FirstOrDefaultAsync();

            return new GetAllByIdForAllReportAnswerQueriesResponse
            {
                AnswerDate = getAllByReportIdForAll.AnswerDate,
                ReportDescription = getAllByReportIdForAll.AnswerText,
                AnswerText = getAllByReportIdForAll.AnswerText,
                ReportTitle = getAllByReportIdForAll.AllReports.ReportTitle

            };
        }
    }
}
