using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Application.Features.CQRS.Auth.Register.EntityFactory
{
    public static class EntityFactories
    {
        public static async Task<(object o , Type t)> CreateEntityForRegister(string role,int companyId , int companyRoleId , User user)
        {
            var createRegister = role switch
            {
                "CompanyAuthor" => (object)new TaskProjectManagementApi.Domain.Entity
                .CompanyAuthor
                {
                    User = user,
                    CompanyId = companyId,
                    IsDeleted = false,
                  

                },
                "Worker" => (object)new Worker
                {
                    User = user,
                    CompanyId = companyId,
                    CompanyRoleId = companyRoleId,
                    IsLeaved = false,
                    IsDeleted = false
                },
                "ReporterWorker" => (object)new TaskProjectManagementApi.Domain.Entity.ReporterWorker
                {
                    User = user,
                    CompanyId = companyId,
                    CompanyRoleId = companyRoleId,
                    IsDeleted = false,
                    
                },
                "SystemOwner" => (object)new SystemOwner
                {
                    User = user,
                    
                    
                },
                _ => throw new ArgumentException("Invalid role")
            };
            return (createRegister,createRegister.GetType());

        }


    }
}
