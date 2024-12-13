using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagement.Core.Entities;
using VacancyManagement.Core.Interfaces;
using VacancyManagementApp.Infrastructure.DAL;

namespace VacancyManagement.Infrastructure.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TestEvaluation>> GetAllEvaluationsAsync()
        {
            return await _context.TestEvaluations
                .Include(e => e.ApplicantCVs) // CV-ləri də əlavə edin
                .ToListAsync();
        }
    }
}
