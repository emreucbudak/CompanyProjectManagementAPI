using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Common;

namespace TaskProjectManagementApi.Domain.Entity
{
    public class CompanyAuthor : BaseEntity
    {
        public CompanyAuthor()
        {
        }

        public CompanyAuthor(int companyId, User user)
        {
            CompanyId = companyId;
            User = user;
        }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }


    }
}
