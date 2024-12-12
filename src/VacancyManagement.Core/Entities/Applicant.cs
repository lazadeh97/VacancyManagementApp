using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Core.Entities;

namespace VacancyManagement.Core.Entities
{
    public class Applicant : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }

        // CV ilə əlaqə
        public ICollection<ApplicantCV> ApplicantCVs { get; set; }
    }
}
