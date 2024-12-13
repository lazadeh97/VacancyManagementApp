using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagement.Business.Services.Interfaces;
using VacancyManagement.Core.Entities;
using VacancyManagement.Core.Interfaces;

namespace VacancyManagement.Business.Services.Implementations
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _repository;

        public ApplicantService(IApplicantRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TestEvaluation>> GetAllEvaluationsAsync()
        {
            return await _repository.GetAllEvaluationsAsync();
        }
    }
}
