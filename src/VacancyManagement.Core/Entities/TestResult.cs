using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagement.Core.Entities
{
    public class TestResult : BaseEntity
    {
        public Guid ApplicantTestId { get; set; } // Namizədin test məlumatı ilə əlaqə
        public Guid TestQuestionId { get; set; } // Sual ilə əlaqə
        public Guid SelectedOptionId { get; set; } // Namizədin seçdiyi cavab variantı
        public bool IsCorrect { get; set; } // Doğru olub-olmaması
        public TestQuestion TestQuestion { get; set; }
        public TestOption SelectedOption { get; set; }
    }

}
