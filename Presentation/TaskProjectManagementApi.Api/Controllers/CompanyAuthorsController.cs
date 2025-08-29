using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Features.CQRS.CompanyAuthor.GetAll;
using TaskProjectManagementApi.Domain.Entity;
using TaskProjectManagementApi.Persistence.AppDbContext;

namespace TaskProjectManagementApi.Api.Controllers
{
    [Authorize(Roles = "SystemOwner")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyAuthorsController : ControllerBase
    {
        private readonly IMediator _context;

        public CompanyAuthorsController(IMediator context)
        {
            _context = context;
        }

        // GET: api/CompanyAuthors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyAuthor>>> GetcompaniesAuthor(GetAllAuthorCommandRequest req)
        {
            var gts = await _context.Send(req);
            return Ok(gts);
        }







    }
}
