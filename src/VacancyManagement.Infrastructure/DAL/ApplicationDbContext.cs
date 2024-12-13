using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagement.Core.Entities;
using VacancyManagementApp.Core.Entities;

namespace VacancyManagementApp.Infrastructure.DAL
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AppRole> Roles { get; set; } // DbSet<AppRole> burada olmalıdır
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<TestOption> TestOptions { get; set; }
        public DbSet<ApplicantTest> ApplicantTests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<ApplicantCV> ApplicantCVs { get; set; }
        public DbSet<TestEvaluation> TestEvaluations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vacancy>().HasData(
                new Vacancy { Id = Guid.NewGuid(), Title = "Software Developer", Description = "Develop software solutions.", IsActive = true },
                new Vacancy { Id = Guid.NewGuid(), Title = "Sales Manager", Description = "Manage sales activities.", IsActive = true }
            );

            modelBuilder.Entity<TestEvaluation>()
               .HasKey(te => te.ApplicantTestId); // ApplicantTestId əsas açar kimi təyin olunur

            // TestEvaluation ilə ApplicantCV arasında bir çox-çox əlaqəni təyin edirik
            modelBuilder.Entity<TestEvaluation>()
                .HasMany(te => te.ApplicantCVs)
                .WithOne()
                .HasForeignKey(cv => cv.ApplicantId)
                .OnDelete(DeleteBehavior.Restrict);  // Foreign Key əlaqəsi

            // TestEvaluation ilə Vacancy arasında bir çoxdan birə əlaqə
            //modelBuilder.Entity<TestEvaluation>()
            //    .HasOne(te => te.Vacancy) // TestEvaluation bir Vacancy ilə əlaqəlidir
            //    .WithMany(v => v.TestEvaluations) // Bir Vacancy bir neçə TestEvaluation-a malik ola bilər
            //    .HasForeignKey(te => te.VacancyId); // VacancyId Foreign Key olaraq istifadə edilir

            modelBuilder.Entity<TestOption>()
            .HasOne(to => to.TestQuestion)
            .WithMany(tq => tq.Options)
            .HasForeignKey(to => to.TestQuestionId);

            modelBuilder.Entity<TestQuestion>()
                .HasOne(tq => tq.Vacancy)
                .WithMany()
                .HasForeignKey(tq => tq.VacancyId);

            // Applicant və ApplicantCV əlaqəsi
            modelBuilder.Entity<ApplicantCV>()
                .HasOne(cv => cv.Applicant)
                .WithMany(a => a.ApplicantCVs)
                .HasForeignKey(cv => cv.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TestResult>()
                .HasOne(tr => tr.TestQuestion)
                .WithMany()
                .HasForeignKey(tr => tr.TestQuestionId)
                .OnDelete(DeleteBehavior.Restrict); // Cyclic delete-in qarşısını almaq üçün

            modelBuilder.Entity<TestResult>()
                .HasOne(tr => tr.SelectedOption)
                .WithMany()
                .HasForeignKey(tr => tr.SelectedOptionId)
                .OnDelete(DeleteBehavior.Restrict); // Yenə eyni səbəb

            modelBuilder.Entity<ApplicantTest>()
                .HasMany(at => at.TestResults)
                .WithOne()
                .HasForeignKey(tr => tr.ApplicantTestId);
        }
    }
}
