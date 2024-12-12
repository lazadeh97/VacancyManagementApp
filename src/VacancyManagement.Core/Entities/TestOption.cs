using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagement.Core.Entities
{
    public class TestOption : BaseEntity
    {
        public string OptionText { get; set; } // Cavabın məzmunu
        public bool IsCorrect { get; set; } // Düzgün cavab olub-olmaması
        public Guid TestQuestionId { get; set; } // Sualla əlaqə
        public TestQuestion TestQuestion { get; set; }
    }
}
