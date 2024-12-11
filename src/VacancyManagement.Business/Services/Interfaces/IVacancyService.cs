using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagement.Core.Entities;
using VacancyManagementApp.Business.DTOs;

namespace VacancyManagement.Business.Services.Interfaces
{
    public interface IVacancyService
    {
        Task<IEnumerable<VacancyDto>> GetAllVacanciesAsync();
        Task AddVacancyAsync(VacancyDto vacancyDto);
        Task ApplyToVacancy(Applicant applicant);
    }
}
