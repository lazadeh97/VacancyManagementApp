using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagement.Business.Services.Interfaces;
using VacancyManagement.Core.Entities;
using VacancyManagementApp.Business.DTOs;
using VacancyManagementApp.Core.Entities;
using VacancyManagementApp.Core.Interfaces;

namespace VacancyManagement.Business.Services.Implementations
{
    public class VacancyService : IVacancyService
    {
        private readonly IGenericRepository<Vacancy> _vacancyRepository;
        private readonly IGenericRepository<Applicant> _applicantRepository;
        private readonly IMapper _mapper;

        public VacancyService(IGenericRepository<Vacancy> vacancyRepository, IGenericRepository<Applicant> applicantRepository, IMapper mapper)
        {
            _vacancyRepository = vacancyRepository;
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VacancyDto>> GetAllVacanciesAsync()
        {
            var vacancies = await _vacancyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<VacancyDto>>(vacancies);
        }

        public async Task AddVacancyAsync(VacancyDto vacancyDto)
        {
            var vacancy = _mapper.Map<Vacancy>(vacancyDto);
            await _vacancyRepository.AddAsync(vacancy);
        }
        public async Task ApplyToVacancy(Applicant applicant)
        {
            await _applicantRepository.AddAsync(applicant);
        }
    }
}
