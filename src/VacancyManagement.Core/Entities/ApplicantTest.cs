using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagement.Core.Entities
{
    public class ApplicantTest : BaseEntity
    {
        public Guid ApplicantId { get; set; } // Namizədin ID-si (əlaqə üçün)
        public Guid VacancyId { get; set; } // Vakansiya ilə əlaqə
        public DateTime StartTime { get; set; } // Testin başlama vaxtı
        public DateTime EndTime { get; set; } // Testin bitmə vaxtı
        public List<TestResult> TestResults { get; set; } // Nəticələr
    }

}
