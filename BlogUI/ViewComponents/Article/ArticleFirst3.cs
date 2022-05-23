﻿using BlogBusiness.Concrete;
using BlogData.Repository.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.ViewComponents.Article
{
    public class ArticleFirst3: ViewComponent
    {
        ArticleManager am = new ArticleManager(new EFArticleRepo());

        public IViewComponentResult Invoke()
        {
            var value = am.GetListFirst3();
            return View(value);

        }


    }
}
