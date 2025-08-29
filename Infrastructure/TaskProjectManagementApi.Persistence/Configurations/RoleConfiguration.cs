using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role()
                {
                    Id = new Guid("11111111-1111-1111-1111-111111111111"),
                    Name = "Worker",
                    NormalizedName = "WORKER",
                    ConcurrencyStamp = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"
                },
                new Role()
                {
                    Id = new Guid("22222222-2222-2222-2222-222222222222"),
                    Name = "CompanyAuthor",
                    NormalizedName = "COMPANYAUTHOR",
                    ConcurrencyStamp = "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"
                },
                new Role()
                {
                    Id = new Guid("33333333-3333-3333-3333-333333333333"),
                    Name = "ReporterWorker",
                    NormalizedName = "REPORTERWORKER",
                    ConcurrencyStamp = "cccccccc-cccc-cccc-cccc-cccccccccccc"
                },
                new Role()
                {
                    Id = new Guid("44444444-4444-4444-4444-444444444444"),
                    Name = "SystemOwner",
                    NormalizedName = "SYSTEMOWNER",
                    ConcurrencyStamp = "dddddddd-dddd-dddd-dddd-dddddddddddd"
                }
            );
        }
    }
}
