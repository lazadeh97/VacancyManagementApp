using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagement.Business.DTOs
{
    public class TestQuestionDto :BaseDto
    {
        public string QuestionText { get; set; }
        public List<TestOptionDto> Options { get; set; }
    }
}
