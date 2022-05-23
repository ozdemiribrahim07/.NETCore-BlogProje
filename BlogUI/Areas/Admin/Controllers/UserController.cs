using BlogBusiness.Concrete;
using BlogBusiness.Validation;
using BlogData.Repository.EF;
using BlogEntity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EFUserRepo());


        public IActionResult Index()
        {
            var value = um.GetList();
            return View(value);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Add(User u)
        {
            UserValidator uv = new UserValidator();
            ValidationResult result = uv.Validate(u);
            if (result.IsValid)
            {
                um.Add(u);
                return RedirectToAction("Index", "User");

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
            var uservalue = um.GetById(id);
            um.Delete(uservalue);
            return RedirectToAction("Index");
        }








    }
}