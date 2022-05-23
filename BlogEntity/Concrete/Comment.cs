using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntity.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentUsername { get; set; }
        public string CommentMail { get; set; }
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentCretedDate { get; set; }
        public bool CommentStatus { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }

    }
}
