using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskProjectManagementApi.Application.Features.CQRS.ReporterWorker.Command.Delete;
using TaskProjectManagementApi.Application.Features.CQRS.ReporterWorker.Command.Update;
using TaskProjectManagementApi.Application.Features.CQRS.ReporterWorker.Queries.GetAll;
using TaskProjectManagementApi.Application.Features.CQRS.ReporterWorker.Queries.GetByCompanyId;
using TaskProjectManagementApi.Domain.Entity;
using TaskProjectManagementApi.Persistence.AppDbContext;

namespace TaskProjectManagementApi.Api.Controllers
{
    [Authorize(Roles = "CompanyAuthor")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReporterWorkersController : ControllerBase
    {
        private readonly IMediator _context;

        public ReporterWorkersController(IMediator context)
        {
            _context = context;
        }

        // GET: api/ReporterWorkers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReporterWorker>>> GetreporterWorkers(GetAllReporterWorkerQueriesRequest req)
        {
            var gts = await _context.Send(req);
            return Ok(gts);
        }

        // GET: api/ReporterWorkers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReporterWorker>> GetReporterWorker(GetReporterWorkerByCompanyIdQueriesRequest req)
        {
            var gts = await _context.Send(req);
            return Ok(gts);
        }
        [HttpPut]
        public async Task<IActionResult> PutReporterWorker(UpdateReporterWorkerCommandRequest req)
        {
            await _context.Send(req);
            return NoContent();
        }




        // DELETE: api/ReporterWorkers/5
        [HttpDelete]
        public async Task<IActionResult> DeleteReporterWorker(DeleteReporterWorkerCommandRequest req)
        {
            await _context.Send(req);

            return NoContent();
        }

 
    }
}
