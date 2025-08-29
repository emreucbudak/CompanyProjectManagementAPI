using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Persistence.Configurations
{
    public class CompanyRoleConfiguration : IEntityTypeConfiguration<CompanyRole>
    {

        public void Configure(EntityTypeBuilder<CompanyRole> builder)
        {
            builder.HasData(new CompanyRole()
            {
                Id = 1,
                CompanyRoleName = "IK",
            },
            new CompanyRole()
            {
                Id   = 2,
                CompanyRoleName = "Müşteri İlişkileri",
            },
            new CompanyRole()
            {
                Id = 3,
                CompanyRoleName = "Resepsiyon",
            },
            new CompanyRole()
            {
                Id = 4,
                CompanyRoleName = "Ağ Sorumlusu",

            },
            new CompanyRole()
            {
                Id = 5,
                CompanyRoleName = "Yazılım Geliştirici",
            },
            new CompanyRole()
            {
                Id = 6,
                CompanyRoleName = "Sistem Yöneticisi",
            }
            );
        }
    }
}
