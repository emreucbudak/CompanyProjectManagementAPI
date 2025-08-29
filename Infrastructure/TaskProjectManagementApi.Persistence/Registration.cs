using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;
using TaskProjectManagementApi.Persistence.AppDbContext;
using TaskProjectManagementApi.Persistence.Repositories;
using TaskProjectManagementApi.Persistence.UnitOfWorks;

namespace TaskProjectManagementApi.Persistence
{
    public static class Registration
    {
        public static void ConfigurePersistence(this IServiceCollection services)
        {
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            



        }
    }
}
