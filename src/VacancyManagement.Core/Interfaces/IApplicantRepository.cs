using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagement.Core.Entities;

namespace VacancyManagement.Core.Interfaces
{
    public interface IApplicantRepository
    {
        Task<List<TestEvaluation>> GetAllEvaluationsAsync();
    }
}
