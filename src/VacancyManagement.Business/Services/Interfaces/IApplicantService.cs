using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagement.Core.Entities;

namespace VacancyManagement.Business.Services.Interfaces
{
    public interface IApplicantService
    {
        Task<List<TestEvaluation>> GetAllEvaluationsAsync();
    }
}
