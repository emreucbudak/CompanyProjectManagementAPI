using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Application.Features.CQRS.Worker.Command.Update
{
    public class UpdateWorkerCommandHandler : IRequestHandler<UpdateWorkerCommandRequest>
    {
        private readonly UserManager<User> userManager;

        public UpdateWorkerCommandHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task Handle(UpdateWorkerCommandRequest request, CancellationToken cancellationToken)
        {
            var getUser = await userManager.FindByEmailAsync(request.Email);
            var result = await userManager.ChangePasswordAsync(getUser, request.OldPassword, request.NewPassword);
            if (!result.Succeeded)
            {
                throw new Exception("Password change failed");
            }
        }
    }
}
