using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagement.Business.DTOs
{
    public class ApplicantTestDto : BaseDto
    {
        public Guid ApplicantId { get; set; }
        public Guid VacancyId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<TestResultDto> TestResults { get; set; }
    }
}
