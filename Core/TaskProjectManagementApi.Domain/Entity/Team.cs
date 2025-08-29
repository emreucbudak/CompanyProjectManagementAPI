using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Common;

namespace TaskProjectManagementApi.Domain.Entity
{
    public class Team : BaseEntity
    {
        public Team()
        {
        }

        public Team(string teamName, ICollection<Worker> workers, int companyId)
        {
            TeamName = teamName;
            Workers = workers;
            CompanyId = companyId;
        }

        public string TeamName { get; set; }
        public ICollection<Worker> Workers { get; set; } 
 
        public int CompanyId { get; set; }
        public Company Company { get; set; }


    }
}
