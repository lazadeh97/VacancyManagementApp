using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagement.Core.Entities;

namespace VacancyManagement.Business.DTOs
{
    public class TestResultDto : BaseDto
    {
        public Guid TestQuestionId { get; set; } // Sualın ID-si
        public string QuestionText { get; set; } // Sualın mətni
        public Guid SelectedOptionId { get; set; } // Namizədin seçdiyi cavabın ID-si
        public string SelectedOptionText { get; set; } // Namizədin seçdiyi cavabın mətni
        public bool IsCorrect { get; set; } // Cavabın düzgün olub-olmaması
    }
}
