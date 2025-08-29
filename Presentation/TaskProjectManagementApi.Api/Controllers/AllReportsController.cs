using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskProjectManagementApi.Application.Features.CQRS.AllReports.Command.Create;
using TaskProjectManagementApi.Application.Features.CQRS.AllReports.Command.Delete;
using TaskProjectManagementApi.Application.Features.CQRS.AllReports.Command.Update;
using TaskProjectManagementApi.Application.Features.CQRS.AllReports.Queries.GetAll;
using TaskProjectManagementApi.Application.Features.CQRS.AllReports.Queries.GetAllByIdReporterWorker;
using TaskProjectManagementApi.Application.Features.CQRS.AllReports.Queries.GetAllByIdWorker;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;
using TaskProjectManagementApi.Domain.Entity;
using TaskProjectManagementApi.Persistence.AppDbContext;

namespace TaskProjectManagementApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllReportsController : ControllerBase
    {
        private readonly IMediator _context;

        public AllReportsController(IMediator context)
        {
            _context = context;
        }

        [Authorize(Roles = "CompanyAuthor")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllReports>>> GetallReports()
        {
            GetAllReportsQueriesRequest request = new();
            var gets = await _context.Send(request);
            return Ok(gets);
        }

        [Authorize(Roles = "Worker")]
        [HttpGet("/worker")]
        public async Task<ActionResult<AllReports>> GetAllReports(GetAllReportsByIdForWorkerQueriesRequest req)
        {
           var get = await _context.Send(req);
            return Ok(get);

        }
        [Authorize(Roles = "ReporterWorker")]
        [HttpGet("/reporterworker")]
        public async Task<ActionResult<AllReports>> GetAllReports(GetAllReportsByIdForReporterWorkerQueriesRequest req)
        {
            var get = await _context.Send(req);
            return Ok(get);

        }
        [Authorize(Roles ="CompanyAuthor,ReporterWorker,Worker")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllReports(UpdateReportsCommandRequest req)
        {
            await _context.Send(req);

            return NoContent();
        }
        [Authorize(Roles = "ReporterWorker,CompanyAuthor")]
        [HttpPost]
        public async Task<ActionResult<AllReports>> PostAllReports(CreateReportCommandRequest allReports)
        {
            await _context.Send(allReports);
            return Created();
        }

        [Authorize(Roles = "ReporterWorker,CompanyAuthor")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllReports(DeleteReportsCommandRequest req)
        {
            await _context.Send(req);

            return NoContent();
        }


    }
}
