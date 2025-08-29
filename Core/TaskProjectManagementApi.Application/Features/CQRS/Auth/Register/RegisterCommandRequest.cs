using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.Auth.Register
{
    public class RegisterCommandRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int CompanyId { get; set; }
        public int? CompanyRoleId { get; set; }


    }
}
