using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Areas.Admin.Models
{
    public class AssignViewModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool IsExist { get; set; }

    }
}
