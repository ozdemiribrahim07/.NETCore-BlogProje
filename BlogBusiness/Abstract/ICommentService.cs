using BlogEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBusiness.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> GetComments(int id);
    }
}
