using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Common;

namespace TaskProjectManagementApi.Domain.Entity
{
    public class Worker  : BaseEntity
    {
        public Worker()
        {
        }

        public Worker(User user, int companyRoleId, bool ısAvailable, bool ısLeaved, int companyId)
        {
            User = user;
            CompanyRoleId = companyRoleId;
            IsAvailable = ısAvailable;
            IsLeaved = ısLeaved;
            CompanyId = companyId;
        }

        public bool IsAvailable { get; set; }
        public bool IsLeaved { get; set; }
        public int CompanyId { get; set; }  
        public Company Company { get; set; }
        public int CompanyRoleId { get; set; }
        public CompanyRole CompanyRole { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
   
    }
}
