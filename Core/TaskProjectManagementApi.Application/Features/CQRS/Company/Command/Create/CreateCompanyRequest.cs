using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Application.Features.CQRS.Company.Command.Create
{
    public class CreateCompanyRequest : IRequest
    {
        public string CompanyName { get; set; }


    }
}
