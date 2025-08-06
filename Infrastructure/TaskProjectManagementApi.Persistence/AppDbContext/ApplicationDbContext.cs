using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Persistence.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Company> companies { get; set; }
        public DbSet<CompanyAuthor> companiesAuthor { get; set; }
        public DbSet<IndividualMissions> individualMissions { get; set; }
        public DbSet<IndividualMissionsAnswer>  IndividualMissionsAnswers { get; set; }
        public DbSet<MissionStatus> missionStatuses { get; set; }
        public DbSet<Team> teams { get; set; }
        public DbSet<TeamMissions> teamMissions { get; set; }
        public DbSet<TeamMissionsAnswer> teamMissionsAnswers { get; set; }
        public DbSet<Worker> workers { get; set; }


    }
}
