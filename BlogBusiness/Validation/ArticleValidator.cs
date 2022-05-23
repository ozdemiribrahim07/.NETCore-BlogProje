using BlogEntity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBusiness.Validation
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.ArticleTitle).NotEmpty().WithMessage("Blog Başlığı Boş Bırakılmamalı.");
            RuleFor(x => x.ArticleTitle).MaximumLength(100).WithMessage("Blog Başlığı 100 karakterden fazla olmamalı.");
            RuleFor(x => x.ArticleTitle).MinimumLength(5).WithMessage("Blog Başlığı En Az 5 karakter olmalı.");
            RuleFor(x => x.ArticleContent).NotEmpty().WithMessage("Blog İçeriği Boş Bırakılmamalı.");
            RuleFor(x => x.ArticleContent).MinimumLength(100).WithMessage("Blog İçeriği En Az 100 karakter olmalı.");
            //RuleFor(x => x.ArticleImage).NotEmpty().WithMessage("Lütfen, bir resim seçiniz.");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Kategori Alanı Boş Bırakılmamalı.");


        }

    }
}
