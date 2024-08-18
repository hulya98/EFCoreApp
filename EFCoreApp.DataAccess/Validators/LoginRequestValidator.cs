using EFCoreApp.Domain.Dtos.Account;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DataAccess.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("{PropertyName} can not be empty");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("{PropertyName} can not be empty");
        }
    }
}
