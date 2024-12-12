using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Business.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "İstifadəçi adı tələb olunur")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifrə tələb olunur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
