using BlogBusiness.Abstract;
using BlogData.Abstract;
using BlogEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBusiness.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Add(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void Delete(Comment t)
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetComments(int id)
        {
            return _commentDal.GetListAll(x => x.ArticleId == id); // Seçilen Article id'sine göre ona yapılmış yorumları getirir.
        }

        public List<Comment> GetList()
        {
            throw new NotImplementedException();
        }


        public void Update(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
