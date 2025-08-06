using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Common;

namespace TaskProjectManagementApi.Domain.Entity
{
    public class Company : BaseEntity
    {
        public Company()
        {
        }

        public Company(string companyName, ICollection<Worker>? workers)
        {
            CompanyName = companyName;
            Workers = workers;
            IsDeleted = false;
        }

        public string CompanyName { get; set; }
        public ICollection<Worker>? Workers { get; set; }    
        
    }
}
