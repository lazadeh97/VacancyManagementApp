using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Core.Entities;

namespace VacancyManagementApp.Infrastructure.DAL
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Vacancy> Vacancies { get; set; }
        //public DbSet<Application> Applications { get; set; }
        //public DbSet<TestQuestion> TestQuestions { get; set; }
        //public DbSet<TestAnswer> TestAnswers { get; set; }
        //public DbSet<CandidateCV> CandidateCVs { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Entity qaydaları burada əlavə edilə bilər
        //    modelBuilder.Entity<Vacancy>().HasMany(v => v.TestQuestions)
        //                                   .WithOne(tq => tq.Vacancy)
        //                                   .HasForeignKey(tq => tq.VacancyId);
        //}
    }
}
