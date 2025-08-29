using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Domain.Entity
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public CompanyAuthor CompanyAuthor { get; set; }
        public Worker Worker { get; set; }
        public ReporterWorker reporterWorker { get; set; }
        public SystemOwner SystemOwner { get; set; }
    }
}
