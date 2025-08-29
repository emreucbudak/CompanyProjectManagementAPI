using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Domain.Entity;

namespace TaskProjectManagementApi.Persistence.AppDbContext
{
    public class ApplicationDbContext :  IdentityDbContext<User,Role,Guid>
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
        public DbSet<AllReports> allReports { get; set; }   
        public DbSet<AnswerStatus> answerStatuses { get; set; }
        public DbSet<ReporterWorker> reporterWorkers { get; set; }
        public DbSet<SystemOwner> systemOwners { get; set; }
        public DbSet<ReportAnswer> reportAnswers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.Entity<Worker>()
                .HasOne(w => w.User)              
                .WithOne(u => u.Worker)           
                .HasForeignKey<Worker>(w => w.UserId) 
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ReporterWorker>()
    .HasOne(w => w.User)            
    .WithOne(u => u.reporterWorker)           
    .HasForeignKey<ReporterWorker>(w => w.UserId) 
    .OnDelete(DeleteBehavior.Cascade);    
            modelBuilder.Entity<CompanyAuthor>()
    .HasOne(w => w.User)              
    .WithOne(u => u.CompanyAuthor)           
    .HasForeignKey<CompanyAuthor>(w => w.UserId) 
    .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SystemOwner>()
    .HasOne(w => w.User)              
    .WithOne(u => u.SystemOwner)          
    .HasForeignKey<SystemOwner>(w => w.UserId) 
    .OnDelete(DeleteBehavior.Cascade);




        }
    }
}
