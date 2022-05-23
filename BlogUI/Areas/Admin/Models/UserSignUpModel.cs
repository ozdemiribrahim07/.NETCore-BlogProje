using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Areas.Admin.Models
{
    public class UserSignUpModel
    {
        [Display(Name ="Mail Adresi")]
        [Required(ErrorMessage = "Lütfen Mail Adresi Giriniz.")]
        [Compare("Email", ErrorMessage = "Şifreler Uyuşmuyor.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre Giriniz.")]
        public string Password { get; set; }

        [Display(Name = "Tekrar Şifre")]
        [Compare("Password", ErrorMessage ="Şifreler Uyuşmuyor.")]
        public string PasswordConfirm { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz.")]
        public string UserName { get; set; }
    }
}
