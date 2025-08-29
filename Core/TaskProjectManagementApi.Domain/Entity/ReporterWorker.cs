using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Common;

namespace TaskProjectManagementApi.Domain.Entity
{
    public class ReporterWorker : BaseEntity
    {
public ReporterWorker() { }

        public ReporterWorker(int companyId, int companyRoleId, User user)
        {
            CompanyId = companyId;
            CompanyRoleId = companyRoleId;
            User = user;
        }

        public int CompanyId { get; set; }  
        public Company Company { get; set; }    
        public int CompanyRoleId { get; set; }  
        public CompanyRole CompanyRole { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
