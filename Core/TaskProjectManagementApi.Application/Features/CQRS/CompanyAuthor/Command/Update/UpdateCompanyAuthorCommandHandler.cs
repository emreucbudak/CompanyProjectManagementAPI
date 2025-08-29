using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Application.Features.CQRS.CompanyAuthor.Command.Update
{
    public class UpdateCompanyAuthorCommandHandler : IRequestHandler<UpdateCompanyAuthorCommandRequest>
    {
        private readonly UserManager<User> userManager;

        public UpdateCompanyAuthorCommandHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task Handle(UpdateCompanyAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            var result = await userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
            if (!result.Succeeded)
            {
                throw new Exception("Password change failed");
            }
        }
    }
}
