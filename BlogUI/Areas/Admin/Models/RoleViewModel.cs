using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Rol adı giriniz.")]
        public string Name { get; set; }
    }
}
