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
    public class ArticleManager : IArticleService
    {
        IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public void Add(Article t)
        {
            _articleDal.Insert(t);
        }

        public void Delete(Article t)
        {
            _articleDal.Delete(t);
        }
        public void Update(Article t)
        {
            _articleDal.Update(t);
        }


        public Article GetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public List<Article> GetList()
        {
            return _articleDal.GetListAll();
        }

        public List<Article> GetListFirst3()
        {
            return _articleDal.GetListAll().Take(4).ToList(); // İlk 4 blog getirir.
        }

        public List<Article> Getlast3()
        {
            return _articleDal.GetListAll().TakeLast(4).ToList(); // Son 4 blog getirir.
        }

        public List<Article> GetArticleById(int id)
        {
            return _articleDal.GetListAll(x => x.ArticleId == id); // Seçilen id'ye göre blog getirir.
        }

        public List<Article> GetBlogListCategorieName()
        {
            return _articleDal.GetBlogListWithCategoryName();
        }

        public List<Article> GetList(int id)
        {
            throw new NotImplementedException();
        }
    }
}
