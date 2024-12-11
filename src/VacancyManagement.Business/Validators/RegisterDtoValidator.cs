using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Business.DTOs;

namespace VacancyManagement.Business.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDtoValidator() 
        {
            // FullName doğrulaması: Boş olmamalıdır və ən azı 3 simvol uzunluğunda olmalıdır
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("FullName is required.")
                .MinimumLength(3).WithMessage("FullName must be at least 3 characters long.");

            // FullName doğrulaması: Boş olmamalıdır və ən azı 3 simvol uzunluğunda olmalıdır
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MinimumLength(3).WithMessage("UserName must be at least 3 characters long.");

            // Email doğrulaması: Boş olmamalıdır və doğru bir email formatı olmalıdır
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            // PhoneNumber doğrulaması: Boş olmamalıdır və düzgün telefon nömrəsi formatı olmalıdır
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Phone number must be a valid format.");

            // Password doğrulaması: Boş olmamalıdır və ən azı 6 simvol uzunluğunda olmalıdır
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
