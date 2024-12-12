using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagement.Core.Entities
{
    public class TestRules
    {
        public int TimePerQuestion { get; set; } // Hər suala ayrılmış vaxt (saniyə ilə)
        public int TotalQuestions { get; set; }  // Ümumi sual sayı
    }
}
