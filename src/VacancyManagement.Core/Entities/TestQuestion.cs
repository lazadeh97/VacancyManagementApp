using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Core.Entities;

namespace VacancyManagement.Core.Entities
{
    public class TestQuestion:BaseEntity
    {
        public string QuestionText { get; set; } // Sualın məzmunu
        public List<TestOption> Options { get; set; } // Cavab variantları
        public Guid VacancyId { get; set; } // Vakansiya ilə əlaqə
        public Vacancy Vacancy { get; set; } // Navigasiya sahəsi
    }
}
