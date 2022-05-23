using BlogBusiness.Concrete;
using BlogBusiness.Validation;
using BlogData.Repository.EF;
using BlogEntity.Concrete;
using BlogUI.Areas.Admin.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepo());
        ArticleManager am = new ArticleManager(new EFArticleRepo());


        public IActionResult Index()
        {
            var value = am.GetBlogListCategorieName();
            return View(value);
        }

        [HttpGet]
        public IActionResult Add()
        {

            List<SelectListItem> categorievalue = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.c = categorievalue;
            return View();
        }

        [HttpPost]
        public IActionResult Add(ImageModel file)
        {

            //ArticleValidator av = new ArticleValidator();
            //ValidationResult result = av.Validate(a);
            Article w = new Article();

            if (!ModelState.IsValid && file != null)
            {
                var extension = Path.GetExtension(file.ArticleImage.FileName);
                var newimage = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogImageFiles/", newimage);
                var stream = new FileStream(location, FileMode.Create);
                file.ArticleImage.CopyTo(stream);
                w.ArticleImage = newimage;

              
                List<SelectListItem> categorievalue = (from x in cm.GetList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString()
                                                       }).ToList();
                ViewBag.c = categorievalue;
                return View(w);

            }
            w.CategoryId = file.CategoryId;
            w.ArticleContent = file.ArticleContent;
            w.ArticleTitle = file.ArticleTitle;
            w.ArticleStatus = true;
            w.ArticleCreatedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            am.Add(w);

            return RedirectToAction("Index");
        }




        public IActionResult Delete(int id)
        {
            var blog = am.GetById(id);
            am.Delete(blog);
            return RedirectToAction("Index", "Blog");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<SelectListItem> categorievalue = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.c = categorievalue;

            var blog = am.GetById(id);
            return View(blog);

        }

        [HttpPost]
        public IActionResult Edit(Article ar, int id)
        {


            if (!ModelState.IsValid)
            {
                List<SelectListItem> categorievalue = (from x in cm.GetList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString()
                                                       }).ToList();
                ViewBag.c = categorievalue;
                return View(ar);

               

            }

            ar.ArticleStatus = true;
            ar.ArticleId = id;
            am.Update(ar);
            return RedirectToAction("Index");

        }




    }
}

