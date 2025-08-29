using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProjectManagementApi.Persistence.AppDbContext
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=emre\\MSSQLSERVER01;Database=CompanyProjectManagement;User Id=sa;Password=emreraftongame63;TrustServerCertificate=True;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
