using BlogBusiness.Concrete;
using BlogData.Repository.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Areas.Admin.ViewComponents
{
    public class BlogList : ViewComponent
    {
        ArticleManager am = new ArticleManager(new EFArticleRepo());
        public IViewComponentResult Invoke()
        {
            var value = am.GetBlogListCategorieName();
            return View(value);
        }

    }
}
