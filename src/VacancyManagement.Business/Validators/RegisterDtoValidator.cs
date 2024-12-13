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
                .MinimumLength(3).WithMessage("Ad və soyad boş olmamalıdır və ya ən azı 3 simvol uzunluğunda olmalıdır.");

            // FullName doğrulaması: Boş olmamalıdır və ən azı 3 simvol uzunluğunda olmalıdır
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MinimumLength(3).WithMessage("İstifadəçi adı boş olmamalıdır və ya ən azı 3 simvol uzunluğunda olmalıdır.");

            // Email doğrulaması: Boş olmamalıdır və doğru bir email formatı olmalıdır
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Email boş olmamalıdır və ya doğru bir email formatı olmalıdır.");

            // PhoneNumber doğrulaması: Boş olmamalıdır və düzgün telefon nömrəsi formatı olmalıdır
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Düzgün telefon nömrəsi formatı olmalıdır və ya boş olmamalıdır.");

            // Password doğrulaması: Boş olmamalıdır və ən azı 6 simvol uzunluğunda olmalıdır
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Şifrə boş olmamalıdır və ya ən azı 6 simvol uzunluğunda olmalıdır.");
        }
    }
}
