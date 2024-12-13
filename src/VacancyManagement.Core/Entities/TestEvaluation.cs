using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Core.Entities;

namespace VacancyManagement.Core.Entities
{
    public class TestEvaluation
    {
        public Guid ApplicantTestId { get; set; } // Namizədin test ID-si
        public Guid ApplicantId { get; set; } // Namizədin ID-si
        public string ApplicantName { get; set; } // Namizədin adı
        public Guid VacancyId { get; set; } // Vakansiya ID-si
        public Vacancy Vacancy { get; set; }
        public string VacancyTitle { get; set; } // Vakansiyanın adı

        public int CorrectAnswers { get; set; } // Düzgün cavab sayı
        public int TotalQuestions { get; set; } // Ümumi sual sayı
        public double Percentage { get; set; } // Nəticə faizi

        public string ResultColor
        {
            get
            {
                if (Percentage >= 75) return "green";
                if (Percentage >= 50) return "yellow";
                return "red";
            }
        }

        // Namizədin CV-ləri
        public List<ApplicantCV> ApplicantCVs { get; set; } = new List<ApplicantCV>();
    }
}
