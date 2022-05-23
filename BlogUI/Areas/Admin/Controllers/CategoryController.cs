using BlogBusiness.Concrete;
using BlogBusiness.Validation;
using BlogData.Repository.EF;
using BlogEntity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepo());

        public IActionResult Index()
        {
            var value = cm.GetList();
            return View(value);
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(Category c)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(c);
            if (result.IsValid)
            {
                c.CategoryStatus = true;

                cm.Add(c);

                return RedirectToAction("Index", "Category");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }


            return View();

        }

        public IActionResult Delete(int id)
        {
            var categoryvalue = cm.GetById(id);
            cm.Delete(categoryvalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = cm.GetById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category c, int id)
        {

            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(c);
            if (result.IsValid)
            {
                c.CategoryStatus = true;
                c.CategoryId = id;
                cm.Update(c);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();







        }


        
    }
}
