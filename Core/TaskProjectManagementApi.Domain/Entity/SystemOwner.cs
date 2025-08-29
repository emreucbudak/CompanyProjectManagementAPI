using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Domain.Entity
{
    public class SystemOwner
    {
        public SystemOwner()
        {
        }

        public SystemOwner(User user)
        {
            User = user;
        }


        public int Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
