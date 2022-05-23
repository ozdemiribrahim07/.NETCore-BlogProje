using BlogEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogData.Abstract
{
    public interface IArticleDal:IGenericDal<Article>
    {
        List<Article> GetBlogListWithCategoryName(); // Blog Listesi içinde kategori id yerine ismini getirir.
    }
}
