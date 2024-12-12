using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagement.Core.Entities
{
    public class ApplicantCV : BaseEntity
    {
        public Guid ApplicantId { get; set; } // Namizədin ID-si
        public Applicant Applicant { get; set; } // Navigasiya sahəsi

        public string FilePath { get; set; }  // Faylın saxlandığı yol
        public string FileName { get; set; }  // Fayl adı
        public string FileType { get; set; }  // Fayl formatı (PDF, DOCX)
    }
}
