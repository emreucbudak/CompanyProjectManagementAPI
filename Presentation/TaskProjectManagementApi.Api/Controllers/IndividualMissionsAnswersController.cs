using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskProjectManagementApi.Application.Features.CQRS.IndividualMissionsAnswer.Command.Create;
using TaskProjectManagementApi.Application.Features.CQRS.IndividualMissionsAnswer.Command.Delete;
using TaskProjectManagementApi.Application.Features.CQRS.IndividualMissionsAnswer.Queries.GetById;
using TaskProjectManagementApi.Domain.Entity;
using TaskProjectManagementApi.Persistence.AppDbContext;

namespace TaskProjectManagementApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualMissionsAnswersController : ControllerBase
    {
        private readonly IMediator _context;

        public IndividualMissionsAnswersController(IMediator context)
        {
            _context = context;
        }


        [Authorize(Roles ="ReporterWorker,Worker,CompanyAuthor")]
        [HttpGet]
        public async Task<ActionResult<IndividualMissionsAnswer>> GetIndividualMissionsAnswer(GetIndividualMissionsAnswerByIdCommandRequest id)
        {
            var gts = await _context.Send(id);
            return Ok(gts);
        }
        [Authorize(Roles ="Worker")]
        [HttpPost]
        public async Task<ActionResult<IndividualMissionsAnswer>> PostIndividualMissionsAnswer(CreateIndividualMissionsAnswerCommandRequest individualMissionsAnswer)
        {
            await _context.Send(individualMissionsAnswer);
            return Ok();
        }
        [Authorize(Roles ="Worker,CompanyAuthor")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIndividualMissionsAnswer(DeleteIndividualMissionsAnswerCommandRequest id)
        {
            await _context.Send(id);


            return NoContent();
        }


    }
}
