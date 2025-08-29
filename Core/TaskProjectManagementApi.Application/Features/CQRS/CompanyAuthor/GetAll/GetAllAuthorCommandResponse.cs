using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Application.Features.CQRS.CompanyAuthor.GetAll
{
    public class GetAllAuthorCommandResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
    }
}
