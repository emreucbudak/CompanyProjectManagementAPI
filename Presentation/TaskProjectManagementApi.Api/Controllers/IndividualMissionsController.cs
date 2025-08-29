using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskProjectManagementApi.Application.Features.CQRS.IndividualMissions.Command.Command.Create;
using TaskProjectManagementApi.Application.Features.CQRS.IndividualMissions.Command.Command.Delete;
using TaskProjectManagementApi.Application.Features.CQRS.IndividualMissions.Command.Command.Update;
using TaskProjectManagementApi.Application.Features.CQRS.IndividualMissions.Queries.GetAll;
using TaskProjectManagementApi.Application.Features.CQRS.IndividualMissions.Queries.GetAllById;
using TaskProjectManagementApi.Domain.Entity;
using TaskProjectManagementApi.Persistence.AppDbContext;

namespace TaskProjectManagementApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualMissionsController : ControllerBase
    {
        private readonly IMediator _context;

        public IndividualMissionsController(IMediator context)
        {
            _context = context;
        }

        [Authorize(Roles = "CompanyAuthor")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndividualMissions>>> GetindividualMissions()
        {
             GetAllIndividualMissionsQueriesRequest req = new();
             var res = await _context.Send(req);
                return Ok(res);
        }

        [Authorize(Roles = "Worker,CompanyAuthor")]
        [HttpGet("/getbyid")]
        public async Task<ActionResult<IndividualMissions>> GetIndividualMissions(GetAllIndividualMissionsByIdQueriesRequest req) 
        {
                var singleReq = await _context.Send(req);
                return Ok(singleReq);
        }

        [Authorize(Roles = "Worker,CompanyAuthor,ReporterWorker")]
        [HttpPut]
        public async Task<IActionResult> PutIndividualMissions(UpdateIndividualMissionsCommandRequest req)
        {
            await _context.Send(req);
            return Ok();
        }

        [Authorize(Roles="CompanyAuthor")]
        [HttpPost]
        public async Task<ActionResult<IndividualMissions>> PostIndividualMissions(CreateIndividualMissionsCreateRequest req )
        {
            await _context.Send(req);
            return Ok();
        }

        [Authorize(Roles ="CompanyAuthor")]
        [HttpDelete]
        public async Task<IActionResult> DeleteIndividualMissions(DeleteIndividualMissionsCommandRequest req )
        {
            await _context.Send(req);
            return NoContent();
        }


    }
}
