using BlogEntity.Concrete;
using BlogUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminRollController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public AdminRollController(RoleManager<Role> roleManager , UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;

        }


        public IActionResult Index()
        {
            var value = _roleManager.Roles.ToList();
            return View(value);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleViewModel p)
        {
            if (ModelState.IsValid)
            {
                Role role = new Role
                {
                    Name = p.Name
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateViewModel update = new RoleUpdateViewModel()
            {
                ID = value.Id,
                Name = value.Name
            };
            return View(update);
        }


        [HttpPost]
        public async Task<IActionResult> Update(RoleUpdateViewModel p)
        {
            var value = _roleManager.Roles.Where(x => x.Id == p.ID).FirstOrDefault();
            value.Name = p.Name;
            var result = await _roleManager.UpdateAsync(value);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(p);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(value);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult RoleList()
        {
            var value = _userManager.Users.ToList();
            return View(value);
        }

        [HttpGet]
        public async  Task<IActionResult> Assign(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var role = _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;

            var roles = await _userManager.GetRolesAsync(user);

            List<AssignViewModel> a = new List<AssignViewModel>();
            foreach (var item in role)
            {
                AssignViewModel m = new AssignViewModel();
                m.RoleId = item.Id;
                m.Name = item.Name;
                m.IsExist = roles.Contains(item.Name);
                a.Add(m);
            }

            return View(a);

        }


        [HttpPost]
        public async Task<IActionResult> Assign(List<AssignViewModel> model)
        {
            var userid = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var item in model)
            {
                if (item.IsExist)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }
            return RedirectToAction("RoleList");
        }



    }
}
