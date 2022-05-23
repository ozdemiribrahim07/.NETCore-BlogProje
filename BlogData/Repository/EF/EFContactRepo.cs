using BlogData.Abstract;
using BlogEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogData.Repository.EF
{
    public class EFContactRepo : EFGenericRepo<Contact>, IContactDal
    {

    }
}
