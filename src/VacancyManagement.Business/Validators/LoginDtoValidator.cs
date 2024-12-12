using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Business.DTOs;

namespace VacancyManagement.Business.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDTO>
    {
        public LoginDtoValidator()
        {
            // UserName doğrulaması: Boş olmamalıdır və ən azı 3 simvol uzunluğunda olmalıdır
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MinimumLength(3).WithMessage("UserName must be at least 3 characters long.");

            // Password doğrulaması: Boş olmamalıdır və ən azı 6 simvol uzunluğunda olmalıdır
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
