using BlogEntity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBusiness.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Bırakılmamalı.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Boş Bırakılmamalı.");
            RuleFor(x => x.Password).MinimumLength(5).WithMessage("Şifre 5 karakterden fazla olmamalı.");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Kullanıcı Adı 50 karakterden az olmalı.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail Ardesi Boş Bırakılmamalı.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Mail Adresi yazılmalıdır. ");
            RuleFor(x => x.Email).EmailAddress();


        }

    }
}
