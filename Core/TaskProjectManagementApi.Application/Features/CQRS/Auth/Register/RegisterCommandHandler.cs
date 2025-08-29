using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Features.CQRS.Auth.Register.EntityFactory;
using TaskProjectManagementApi.Application.Features.CQRS.Auth.Rules;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Application.Features.CQRS.Auth.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;
        public RegisterCommandHandler(AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            unit = unitOfWork;
        }
        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

            User user = mapper.Map<User>(request);

            user.UserName = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();
            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync(request.Role))
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = request.Role,
                        NormalizedName = request.Role.ToUpper(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    });

                await userManager.AddToRoleAsync(user, request.Role);
            }
             (object entity, Type type) = await EntityFactories.CreateEntityForRegister(request.Role, request.CompanyId, request.CompanyRoleId ?? 0, user);
            var interfaceType = typeof(IUnitOfWork);
            var getGenericMethod = interfaceType.GetMethod("GetWriteRepository")
                .MakeGenericMethod(type);
            var repository = getGenericMethod.Invoke(unit, null);
            var addMethod = repository.GetType().GetMethod("AddAsync");
            await (Task)addMethod.Invoke(repository, new object[] { entity });
           





            await unit.SaveAsync();



            return Unit.Value;
        }
    }
}
