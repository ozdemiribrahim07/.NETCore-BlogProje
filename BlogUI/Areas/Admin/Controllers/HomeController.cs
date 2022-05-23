using BlogBusiness.Abstract;
using BlogBusiness.Concrete;
using BlogData.ContextFile;
using BlogEntity.Concrete;
using BlogUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        Context c = new Context();

     
        public IActionResult Index() 
        {
            ViewBag.v1 = c.Categories.Count().ToString();
            ViewBag.v2 = c.Articles.Count().ToString();
            ViewBag.v3 = c.Users.Count().ToString();
            ViewBag.v4 = c.Roles.Count().ToString();
            return View();
        }
    }
}
