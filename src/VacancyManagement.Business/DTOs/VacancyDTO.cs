using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagement.Business.DTOs;

namespace VacancyManagementApp.Business.DTOs
{
    public class VacancyDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
