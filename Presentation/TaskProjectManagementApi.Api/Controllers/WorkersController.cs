using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskProjectManagementApi.Application.Features.CQRS.Worker.Command.Delete;
using TaskProjectManagementApi.Application.Features.CQRS.Worker.Command.Update;
using TaskProjectManagementApi.Domain.Entity;
using TaskProjectManagementApi.Persistence.AppDbContext;

namespace TaskProjectManagementApi.Api.Controllers
{
    [Authorize(Roles = "CompanyAuthor")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IMediator _context;

        public WorkersController(IMediator context)
        {
            _context = context;
        }

        // GET: api/Workers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Worker>>> Getworkers()
        {
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutWorker(UpdateWorkerCommandRequest req)
        {
            await _context.Send(req);

            return NoContent();
        }



        // DELETE: api/Workers/5
        [HttpDelete]
        public async Task<IActionResult> DeleteWorker(DeleteWorkerCommandRequest id)
        {

            await _context.Send(id);
            return NoContent();
        }

    }
}
