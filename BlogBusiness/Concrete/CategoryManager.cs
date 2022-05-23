﻿using BlogBusiness.Abstract;
using BlogData.Abstract;
using BlogEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBusiness.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void Delete(Category t)
        {
            _categoryDal.Delete(t);
        }
        public void Update(Category t)
        {
            _categoryDal.Update(t);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);        
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }


    }
}
