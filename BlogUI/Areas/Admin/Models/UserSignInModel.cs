using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Areas.Admin.Models
{
    public class UserSignInModel
    {


        [Required(ErrorMessage = "Mail Adresinizi Giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrenizi Giriniz.")]
        public string Password { get; set; }


    }
}
