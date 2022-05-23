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
    public class ContactController : Controller
    {

        ContactManager cm = new ContactManager(new EFContactRepo());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(Contact c)
        {
            // Ziyaretçinin iletişim bölümünden mesaj atmasını sağlar.
            c.ContactCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.ContactStatus = true;
            cm.Add(c);
            return View();
        }


    }
}
