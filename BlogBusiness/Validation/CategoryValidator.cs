using BlogEntity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBusiness.Validation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Bırakılmamalı.");
            RuleFor(x => x.CategoryName).MaximumLength(100).WithMessage("Kategori Adı 100 karakterden fazla olmamalı.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori Adı En Az 3 karakter olmalı.");
            RuleFor(x => x.CategoryDesc).NotEmpty().WithMessage("Kategori Açıklaması Boş Bırakılmamalı.");
            RuleFor(x => x.CategoryDesc).MinimumLength(10).WithMessage("Kategori Açıklaması 10 karakterden fazla olmalı.");


        }

    }
}
