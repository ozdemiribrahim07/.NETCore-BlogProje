using BlogData.Abstract;
using BlogData.ContextFile;
using BlogEntity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogData.Repository.EF
{
    public class EFArticleRepo : EFGenericRepo<Article>, IArticleDal
    {
        public List<Article> GetBlogListWithCategoryName()
        {
            using(var b = new Context())
            {
                return b.Articles.Include(x => x.Category).ToList(); //Blog tablosunda Kategori id'si yerine ismini getirmesi için gerekli olan kod.
            }
        }
    }
}
