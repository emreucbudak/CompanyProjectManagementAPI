using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskProjectManagementApi.Application.Features.CQRS.ReportAnswer.Command.Create;
using TaskProjectManagementApi.Application.Features.CQRS.ReportAnswer.Command.Delete;
using TaskProjectManagementApi.Application.Features.CQRS.ReportAnswer.Queries.GetAllByIdForAll;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;
using TaskProjectManagementApi.Domain.Entity;
using TaskProjectManagementApi.Persistence.AppDbContext;

namespace TaskProjectManagementApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportAnswersController : ControllerBase
    {
        private readonly IMediator _context;

        public ReportAnswersController(IMediator context)
        {
            _context = context;
        }
        [Authorize(Roles = "CompanyAuthor,ReporterWorker")]
        [HttpGet]
        public async Task<ActionResult<ReportAnswer>> GetReportAnswer(GetAllByIdForAllReportAnswerQueriesRequest req)
        {
            var gts =await _context.Send(req);

            return Ok(gts);
        }
        [Authorize(Roles = "CompanyAuthor")]
        [HttpPost]
        public async Task<ActionResult<ReportAnswer>> PostReportAnswer(CreateReportAnswerCommandRequest reportAnswer)
        {
            await _context.Send(reportAnswer);
            return NoContent();
        }
        [Authorize(Roles = "CompanyAuthor")]
        [HttpDelete]
        public async Task<IActionResult> DeleteReportAnswer(DeleteReportAnswerCommandRequest req)
        {

            await _context.Send(req);
            return NoContent();
        }


    }
}
