using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Business.DTOs;
using VacancyManagementApp.Core.Entities;

namespace VacancyManagement.Business.Profiles
{
    public class CustomMapper : Profile
    {
        public CustomMapper()
        {
            CreateMap<RegisterDTO, AppUser>();
        }
    }
}
