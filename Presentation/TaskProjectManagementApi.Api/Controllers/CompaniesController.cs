using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskProjectManagementApi.Application.Features.CQRS.Company.Command.Create;
using TaskProjectManagementApi.Application.Features.CQRS.Company.Command.Delete;
using TaskProjectManagementApi.Application.Features.CQRS.Company.Queries.GetAllQueries;
using TaskProjectManagementApi.Domain.Entity;
using TaskProjectManagementApi.Persistence.AppDbContext;

namespace TaskProjectManagementApi.Api.Controllers
{
    [Authorize(Roles = "SystemOwner")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _context;
        public CompaniesController(IMediator context)
        {
            _context = context;
        }

    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> Getcompanies()
        {
            var ds = await _context.Send(new GetAllCompanyQueriesRequest());
            return Ok(ds);
        }



        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(CreateCompanyRequest company)
        {
            await _context.Send(company);

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(DeleteCompanyRequest dt)
        {
            await _context.Send(dt);
            return NoContent();
        }


    }
}
