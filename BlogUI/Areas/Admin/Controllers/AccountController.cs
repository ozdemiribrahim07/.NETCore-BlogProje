using BlogEntity.Concrete;
using BlogUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogUI.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult UserRegister()
        {
            UserSignUpModel model = new UserSignUpModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserSignUpModel p)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await _userManager.FindByEmailAsync(p.Email);
                if (userCheck == null)
                {
                    var user = new User
                    {
                        
                        UserName = p.Email,
                        NormalizedUserName = p.Email,
                        Email = p.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                    };
                    var result = await _userManager.CreateAsync(user, p.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        if (result.Errors.Count() > 0)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        return View(p);
                    }
                }
                else
                {
                    ModelState.AddModelError("message", "Email already exists.");
                    return View(p);
                }
            }
            return View(p);

        }



        [HttpGet]
        public IActionResult Login()
        {
            UserSignInModel model = new UserSignInModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserSignInModel u)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(u.Email, u.Password, true, false);

                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Index","Home");
                }
               
               
            }
            return View(u);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

    }

}



