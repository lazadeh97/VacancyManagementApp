using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Core.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CVPath { get; set; }
        public int Score { get; set; }
        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}
