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
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public void Add(Role t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Role t)
        {
            throw new NotImplementedException();
        }

        public Role GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(Role t)
        {
            throw new NotImplementedException();
        }
    }
}
