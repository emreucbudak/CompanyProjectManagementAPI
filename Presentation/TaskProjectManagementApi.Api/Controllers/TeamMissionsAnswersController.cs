using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskProjectManagementApi.Application.Features.CQRS.TeamMissionsAnswer.Command.Create;
using TaskProjectManagementApi.Application.Features.CQRS.TeamMissionsAnswer.Command.Delete;
using TaskProjectManagementApi.Application.Features.CQRS.TeamMissionsAnswer.Command.Update;
using TaskProjectManagementApi.Application.Features.CQRS.TeamMissionsAnswer.Queries;
using TaskProjectManagementApi.Domain.Entity;
using TaskProjectManagementApi.Persistence.AppDbContext;

namespace TaskProjectManagementApi.Api.Controllers
{

    [Authorize(Roles = "CompanyAuthor,Worker")]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMissionsAnswersController : ControllerBase
    {
        private readonly IMediator _context;

        public TeamMissionsAnswersController(IMediator context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMissionsAnswer>>> GetteamMissionsAnswers(GetAllTeamMissionsAnswerQueriesRequest req)
        {
            var gts = await _context.Send(req);
            return Ok(gts);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamMissionsAnswer(UpdateTeamMissionsAnswerCommandRequest req)
        {
            await _context.Send(req);


            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<TeamMissionsAnswer>> PostTeamMissionsAnswer(CreateTeamMissionsAnswerCommandRequest teamMissionsAnswer)
        {
            await _context.Send(teamMissionsAnswer);
            return NoContent();
        }

   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMissionsAnswer(DeleteTeamMissionsAnswerCommandRequest req)
        {
            await _context.Send(req);


            return NoContent();
        }


    }
}
