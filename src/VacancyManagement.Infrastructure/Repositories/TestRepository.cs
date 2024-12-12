using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagement.Core.Entities;
using VacancyManagement.Core.Interfaces;
using VacancyManagementApp.Infrastructure.DAL;
using VacancyManagementApp.Infrastructure.Repositories;

namespace VacancyManagement.Infrastructure.Repositories
{
    public class TestRepository : GenericRepository<TestQuestion>, ITestRepository
    {
        private readonly ApplicationDbContext _context;

        public TestRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<TestQuestion>> GetQuestionsByVacancyIdAsync(Guid vacancyId)
        {
            return await _context.TestQuestions
                .Where(q => q.VacancyId == vacancyId)
                .Include(q => q.Options)
                .ToListAsync();
        }
    }
}
