using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagement.Core.Entities;
using VacancyManagementApp.Core.Interfaces;

namespace VacancyManagement.Core.Interfaces
{
    public interface ITestQuestionRepository : IGenericRepository<TestQuestion>
    {
        Task<List<TestQuestion>> GetQuestionsByVacancyIdAsync(Guid vacancyId);
    }
}
