using BlogBusiness.Concrete;
using BlogData.Repository.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.ViewComponents.Comment
{
    public class CommentListByArticle:ViewComponent
    {
        CommentManager cm = new CommentManager(new EFCommentRepo());

        public IViewComponentResult Invoke(int id)
        {
            var value = cm.GetComments(id);
            return View(value);
        }

    }
}
