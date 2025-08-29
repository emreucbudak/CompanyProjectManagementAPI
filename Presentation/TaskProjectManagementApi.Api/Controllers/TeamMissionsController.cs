using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Features.CQRS.TeamMissions.Command.Create;
using TaskProjectManagementApi.Application.Features.CQRS.TeamMissions.Command.Delete;
using TaskProjectManagementApi.Application.Features.CQRS.TeamMissions.Command.Update;
using TaskProjectManagementApi.Application.Features.CQRS.TeamMissions.Queries.GetAllQueries;
using TaskProjectManagementApi.Domain.Entity;
using TaskProjectManagementApi.Persistence.AppDbContext;

namespace TaskProjectManagementApi.Api.Controllers
{

    [Authorize(Roles = "CompanyAuthor,Worker")]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMissionsController : ControllerBase
    {
        private readonly IMediator _context;

        public TeamMissionsController(IMediator context)
        {
            _context = context;
        }

        // GET: api/TeamMissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMissions>>> GetteamMissions(GetAllTeamMissionsQueriesRequest req)
        {
            var gts = await _context.Send(req); 
            return Ok(gts);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamMissions(UpdateTeamMissionsCommandRequest teamMissions)
        {

            await _context.Send(teamMissions);
            return NoContent();
        }

        // POST: api/TeamMissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeamMissions>> PostTeamMissions(CreateTeamMissionsCommandRequest req)
        {
            await _context.Send(req);
            return NoContent();

        }

        // DELETE: api/TeamMissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMissions(DeleteTeamMissionsCommandRequest req)
        {
            await _context.Send(req);


            return NoContent();
        }


    }
}
