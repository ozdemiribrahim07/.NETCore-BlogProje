using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntity.Concrete
{
    public class User:IdentityUser<int>
    {
        [Key]
        public string Password { get; set; }
        public string Picture { get; set; }
        public bool Remember { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
