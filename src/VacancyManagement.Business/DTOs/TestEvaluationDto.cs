using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagement.Business.DTOs
{
    public class TestEvaluationDto : BaseDto
    {
        public Guid ApplicantTestId { get; set; }
        public int CorrectAnswers { get; set; }
        public int TotalQuestions { get; set; }
        public double Percentage { get; set; }

        public string ResultColor
        {
            get
            {
                if (Percentage >= 75) return "green";
                if (Percentage >= 50) return "yellow";
                return "red";
            }
        }
    }
}
