using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntity.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string ContactUsername { get; set; }
        public string ContactTitle { get; set; }
        public string ContactMessage { get; set; }
        public string ContactMail { get; set; }
        public DateTime ContactCreateDate { get; set; }
        public bool ContactStatus { get; set; }

    }
}
