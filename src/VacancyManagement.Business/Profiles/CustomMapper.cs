using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagement.Business.DTOs;
using VacancyManagement.Core.Entities;
using VacancyManagementApp.Business.DTOs;
using VacancyManagementApp.Core.Entities;

namespace VacancyManagement.Business.Profiles
{
    public class CustomMapper : Profile
    {
        public CustomMapper()
        {
            CreateMap<Vacancy, VacancyDto>().ReverseMap();
            CreateMap<TestQuestion, TestQuestionDto>().ReverseMap();
            CreateMap<TestOption, TestOptionDto>().ReverseMap();
            CreateMap<TestResult, TestResultDto>().ReverseMap();
            CreateMap<ApplicantTest, ApplicantTestDto>().ReverseMap();
            CreateMap<RegisterDTO, AppUser>();
        }
    }
}
