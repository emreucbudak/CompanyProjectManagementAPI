using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskProjectManagementApi.Application.Features.CQRS.Team.Command.Create;
using TaskProjectManagementApi.Application.Features.CQRS.Team.Command.Delete;
using TaskProjectManagementApi.Application.Features.CQRS.Team.Queries.GetAll;
using TaskProjectManagementApi.Application.Features.CQRS.Team.Queries.GetByWorkerId;
using TaskProjectManagementApi.Domain.Entity;
using TaskProjectManagementApi.Persistence.AppDbContext;

namespace TaskProjectManagementApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator _context;

        public TeamsController(IMediator context)
        {
            _context = context;
        }

        // GET: api/Teams
        [Authorize(Roles ="CompanyAuthor")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> Getteams(GetAllTeamCommandRequest req)
        {
            var gts = await _context.Send(req);
            return Ok(gts);
        }
        [Authorize(Roles= "CompanyAuthor,Worker")]
        [HttpGet("getbyworkerid")]
        public async Task<ActionResult<IEnumerable<Team>>> GetByWorkerId(GetTeamByWorkerIdQueriesRequest req)
        {
            var gts = await _context.Send(req);
            return Ok(gts);
        }


        [Authorize(Roles = "CompanyAuthor")]
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(CreateTeamCommandRequest team)
        {
            await _context.Send(team);
            return NoContent();
        }
        [Authorize(Roles = "CompanyAuthor")]
        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(DeleteTeamCommandRequest id)
        {
            await _context.Send(id);

            return NoContent();
        }


    }
}
