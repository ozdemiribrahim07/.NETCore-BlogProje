using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntity.Concrete
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilmemeli.")]
        [MinLength(3, ErrorMessage = "En az 2 karakter girilmeli.")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter girilmeli.")]
        public string ArticleTitle { get; set; }

        [MinLength(100, ErrorMessage = "En az 100 karakter girilmeli.")]
        [Required(ErrorMessage = "Bu alan boş geçilmemeli.")]
        public string ArticleContent { get; set; }
        
        public string ArticleImage { get; set; }
        public int ViewsCount { get; set; }
        public int CommentCount { get; set; }
        public DateTime ArticleCreatedDate { get; set; }
        public bool ArticleStatus { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Id { get; set; }
        public User User { get; set; }


    }
}
