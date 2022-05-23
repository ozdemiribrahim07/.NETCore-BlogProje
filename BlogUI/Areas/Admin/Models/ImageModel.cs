using BlogEntity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Areas.Admin.Models
{
    public class ImageModel
    {
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public bool ArticleStatus { get; set; }
        public int ArticleId { get; set; }
        public IFormFile ArticleImage { get; set; }
        public int CategoryId { get; set; }
        public DateTime ArticleCreatedDate { get; set; }

    }
   

}
