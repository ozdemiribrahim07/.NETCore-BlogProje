using BlogBusiness.Concrete;
using BlogData.Repository.EF;
using BlogEntity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Controllers
{
    public class ArticleController : Controller
    {
        ArticleManager am = new ArticleManager(new EFArticleRepo());
        CommentManager cm = new CommentManager(new EFCommentRepo());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ArticleDetails(int id)
        {
            ViewBag.c = id;
            var value = am.GetArticleById(id);
            return View(value);
        }





    }
}
