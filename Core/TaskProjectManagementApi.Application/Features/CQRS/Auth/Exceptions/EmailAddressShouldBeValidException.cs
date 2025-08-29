using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Bases;

namespace TaskProjectManagementApi.Application.Features.CQRS.Auth.Exceptions
{
    public class EmailAddressShouldBeValidException : BaseException
    {
        public EmailAddressShouldBeValidException() : base("Böyle bir email adresi bulunmamaktadır.") { }
    }
}
