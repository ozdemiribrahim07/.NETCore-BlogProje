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
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EFCommentRepo());

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment c, int id)
        {
            c.CommentCretedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.CommentStatus = true;
            cm.GetComments(id);
            return RedirectToAction("Index", "Article");
        }




    }
}
